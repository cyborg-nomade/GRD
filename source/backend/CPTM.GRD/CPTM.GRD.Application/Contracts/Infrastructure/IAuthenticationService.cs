namespace CPTM.GRD.Application.Contracts.Infrastructure;

public interface IAuthenticationService
{
    Task<bool> ExistsAd(string username);
}