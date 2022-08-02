using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Views;
using CPTM.GRD.Application.DTOs.AccessControl.User;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Models.AD;
using CPTM.GRD.Application.Models.Settings;
using CPTM.GRD.Common;
using CPTM.GRD.Domain.AccessControl;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using Claim = System.Security.Claims.Claim;

namespace CPTM.GRD.Infrastructure.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private AuthenticationServiceSettings AuthenticationServiceSettings { get; }
    private readonly JwtSettings _jwtSettings;
    private readonly IViewUsuarioRepository _viewUsuarioRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public AuthenticationService(IOptions<AuthenticationServiceSettings> authOptions, IOptions<JwtSettings> jwtSettings,
        IViewUsuarioRepository viewUsuarioRepository, IUserRepository userRepository, IMapper mapper)
    {
        _jwtSettings = jwtSettings.Value;
        _viewUsuarioRepository = viewUsuarioRepository;
        _userRepository = userRepository;
        _mapper = mapper;
        AuthenticationServiceSettings = authOptions.Value;
    }

    public async Task<bool> ExistsAd(string username)
    {
        var response = await SendRequest("existe-usuario", username);
        if (response.Content == null) throw new NotFoundException(nameof(response), nameof(response.Content));
        var deserializedResponse = JObject.Parse(response.Content);
        var existe = deserializedResponse.GetValue("existe");
        return Convert.ToBoolean(existe);
    }

    public async Task<bool> Authenticate(AuthUser user)
    {
        var response = await SendRequest("autenticar", user: user);
        if (response.Content == null) throw new NotFoundException(nameof(response.Content), user);
        var deserializedResponse = JObject.Parse(response.Content);
        var autenticado = deserializedResponse.GetValue("autenticado");
        return Convert.ToBoolean(autenticado);
    }

    public async Task<UsuarioAD> GetUsuarioAd(string username)
    {
        var response = await SendRequest("obter-usuario", username);
        if (response.Content == null) throw new NotFoundException(nameof(response.Content), username);
        return JsonConvert.DeserializeObject<UsuarioAD>(response.Content) ?? throw new InvalidOperationException();
    }

    public async Task<GrupoAD> GetGroupAd(string groupName)
    {
        var response = await SendRequest("obter-grupo", groupName);
        if (response.Content == null) throw new NotFoundException(nameof(response.Content), groupName);
        return JsonConvert.DeserializeObject<GrupoAD>(response.Content) ?? throw new InvalidOperationException();
    }

    public async Task<bool> IsGerente(string username)
    {
        var userAd = await GetUsuarioAd(username);
        var gerentesGrupo = await GetGroupAd("GERENTES");
        return gerentesGrupo.Membros.Contains(userAd.NomeDistinto);
    }

    public async Task<bool> IsDiretor(string username)
    {
        var userAd = await GetUsuarioAd(username);
        var gerentesGrupo = await GetGroupAd("DIRETORES");
        return gerentesGrupo.Membros.Contains(userAd.NomeDistinto);
    }

    public string GenerateToken(User user)
    {
        var areaClaims = user.AreasAcesso.Select(group => new Claim(CustomClaimTypes.AccessGroups, group.Sigla))
            .ToList();

        var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UsernameAd),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(CustomClaimTypes.Uid, user.Id.ToString()),
                new Claim(CustomClaimTypes.AccessLevel, user.NivelAcesso.ToString()),
            }
            .Union(areaClaims);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
            signingCredentials: signingCredentials);
        var tokenString = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        return tokenString;
    }

    private async Task<RestResponse> SendRequest(string endpoint, string username = "", AuthUser? user = null)
    {
        ServicePointManager.ServerCertificateValidationCallback +=
            (sender, certificate, chain, sslPolicyErrors) => true;

        var authClient = new RestClient(AuthenticationServiceSettings.AbiUrl + endpoint + username);

        var authRequest = new RestRequest();
        authRequest.AddHeader("Content-Type", "application/json");
        if (user != null)
        {
            authRequest.Method = Method.Post;
            authRequest.AddJsonBody(user);
        }

        var response = await authClient.ExecuteAsync(authRequest);
        var enviado = response.IsSuccessful;

        if (enviado)
        {
            return response;
        }

        throw response.ErrorException!;
    }
}