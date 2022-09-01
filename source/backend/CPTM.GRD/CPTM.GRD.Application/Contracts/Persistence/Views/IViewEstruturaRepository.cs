using CPTM.GRD.Application.Responses;
using CPTM.GRD.Domain.AccessControl;

namespace CPTM.GRD.Application.Contracts.Persistence.Views;

public interface IViewEstruturaRepository
{
    Task<Group> GetGroup(string sigla);
    Task<EstruturaResponse> GetEstrutura();
}