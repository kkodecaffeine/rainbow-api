using MediatR;
using RainbowApp.Application.Tasks.Dto;

namespace RainbowApp.Application.Tasks.Queries
{
    public class GetServiceProviderByMgtNoQuery : IRequest<ServiceProviderDto>
    {
        public string MgtNo { get; set; }
    }
}
