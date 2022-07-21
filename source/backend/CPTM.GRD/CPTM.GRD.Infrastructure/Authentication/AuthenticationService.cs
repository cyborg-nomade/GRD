using System.Net;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Views;
using CPTM.GRD.Application.DTOs.AccessControl.User;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Models;
using CPTM.GRD.Domain.AccessControl;
using Newtonsoft.Json;
using RestSharp;

namespace CPTM.GRD.Infrastructure.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IViewUsuarioRepository _viewUsuarioRepository;
    private readonly IUserRepository _userRepository;
    private const string AbiUrl = "http://localhost:7000/ABI/api/ad/";

    public AuthenticationService(IViewUsuarioRepository viewUsuarioRepository, IUserRepository userRepository)
    {
        _viewUsuarioRepository = viewUsuarioRepository;
        _userRepository = userRepository;
    }

    public async Task<bool> ExistsAd(string username)
    {
        var response = await SendRequest("existe-usuario", username);
        return Convert.ToBoolean(response.Content);
    }

    public async Task<User> Login(AuthUser user)
    {
        var response = await SendRequest("autenticar", user: user);
        if (response.Content == null) throw new NotFoundException(nameof(response.Content), user);

        var autenticado = Convert.ToBoolean(response.Content);
        if (!autenticado)
        {
            throw new NotFoundException(nameof(response.Content), user);
        }

        return await _userRepository.GetByUsername(user.Username);
    }

    public async Task<UsuarioAD> GetUsuarioAD(string username)
    {
        var response = await SendRequest("obter-usuario", username);
        if (response.Content == null) throw new NotFoundException(nameof(response.Content), username);
        return JsonConvert.DeserializeObject<UsuarioAD>(response.Content) ?? throw new InvalidOperationException();
    }

    private static async Task<RestResponse> SendRequest(string endpoint, string username = "", AuthUser? user = null)
    {
        ServicePointManager.ServerCertificateValidationCallback +=
            (sender, certificate, chain, sslPolicyErrors) => true;

        var emailClient = new RestClient(AbiUrl + endpoint + username);

        var emailRequest = new RestRequest();
        emailRequest.AddHeader("Content-Type", "application/json");
        if (user != null)
        {
            emailRequest.Method = Method.Post;
            emailRequest.AddJsonBody(user);
        }

        var response = await emailClient.ExecuteAsync(emailRequest);
        var enviado = response.IsSuccessful;

        if (enviado)
        {
            return response;
        }

        throw response.ErrorException!;
    }
}