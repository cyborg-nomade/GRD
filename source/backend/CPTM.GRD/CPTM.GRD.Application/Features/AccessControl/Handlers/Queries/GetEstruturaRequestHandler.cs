using CPTM.GRD.Application.Contracts.Persistence.Views;
using CPTM.GRD.Application.Features.AccessControl.Requests.Queries;
using CPTM.GRD.Application.Responses;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Handlers.Queries;

public class GetEstruturaRequestHandler : IRequestHandler<GetEstruturaRequest, EstruturaResponse>
{
    private readonly IViewEstruturaRepository _viewEstruturaRepository;

    public GetEstruturaRequestHandler(IViewEstruturaRepository viewEstruturaRepository)
    {
        _viewEstruturaRepository = viewEstruturaRepository;
    }

    public async Task<EstruturaResponse> Handle(GetEstruturaRequest request, CancellationToken cancellationToken)
    {
        return await _viewEstruturaRepository.GetEstrutura();
    }
}