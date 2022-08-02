using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Views;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Models.AD;
using CPTM.GRD.Common;
using CPTM.GRD.Domain.AccessControl;
using Microsoft.EntityFrameworkCore;

namespace CPTM.GRD.Persistence.Repositories.AccessControl;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly GrdContext _grdContext;
    private readonly IGroupRepository _groupRepository;
    private readonly IViewUsuarioRepository _viewUsuarioRepository;

    public UserRepository(GrdContext grdContext,
        IGroupRepository groupRepository,
        IViewUsuarioRepository viewUsuarioRepository) : base(grdContext)
    {
        _grdContext = grdContext;
        _groupRepository = groupRepository;
        _viewUsuarioRepository = viewUsuarioRepository;
    }

    public async Task<IReadOnlyList<User>> GetByLevel(AccessLevel level)
    {
        return await _grdContext.Users.Where(u => u.NivelAcesso == level).ToListAsync();
    }

    public async Task<IReadOnlyList<User>> GetByGroup(int gid)
    {
        var group = await _grdContext.Groups.FindAsync(gid);
        if (group == null) throw new NotFoundException(nameof(group), gid);
        return await _grdContext.Users.Where(u => u.AreasAcesso.Contains(group)).ToListAsync();
    }

    public async Task<IReadOnlyList<User>> GetByGroupAndLevel(int gid, AccessLevel level)
    {
        var group = await _grdContext.Groups.FindAsync(gid);
        if (group == null) throw new NotFoundException(nameof(group), gid);
        return await _grdContext.Users.Where(u => u.AreasAcesso.Contains(group) && u.NivelAcesso == level)
            .ToListAsync();
    }

    public async Task<User?> GetByUsername(string username)
    {
        var user = await _grdContext.Users.Where(u => u.UsernameAd.ToUpper() == username.ToUpper())
            .SingleOrDefaultAsync();
        return user;
    }

    public async Task<bool> ExistsUsername(string username)
    {
        var user = await GetByUsername(username);
        return user != null;
    }

    public async Task<User> GetOrAddGerente(UsuarioAD usuarioAd)
    {
        return await GetOrAdd(usuarioAd, AccessLevel.Gerente);
    }

    public async Task<User> GetOrAddDiretor(UsuarioAD usuarioAd)
    {
        return await GetOrAdd(usuarioAd, AccessLevel.Diretor);
    }

    public async Task<User> GetOrAddGrgMember(UsuarioAD usuarioAd)
    {
        return await GetOrAdd(usuarioAd, AccessLevel.Grg);
    }

    public async Task<User> GetOrAddSysAdmin(UsuarioAD usuarioAd)
    {
        return await GetOrAdd(usuarioAd, AccessLevel.SysAdmin);
    }

    private async Task<User> GetOrAdd(UsuarioAD usuarioAd, AccessLevel accessLevel)
    {
        if (!await ExistsUsername(usuarioAd.Login)) return await AddFromUsuarioAd(usuarioAd, accessLevel);

        var user = await GetByUsername(usuarioAd.Login);
        user!.NivelAcesso = accessLevel;
        return await Update(user);
    }

    public async Task<User> AddFromUsuarioAd(UsuarioAD usuarioAd, AccessLevel accessLevel)
    {
        var newUser = new User()
        {
            UsernameAd = usuarioAd.Login,
            Nome = usuarioAd.Nome,
            Email = usuarioAd.Email,
            Funcao = await _viewUsuarioRepository.GetCargoCPU(usuarioAd.Login) ?? string.Empty,
            NivelAcesso = accessLevel,
            AreasAcesso = new List<Group>()
            {
                await _groupRepository.GetOrAddBySigla(usuarioAd.Departamento)
            }
        };
        return await Add(newUser);
    }
}