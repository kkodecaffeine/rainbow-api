using MediatR;
using RainbowApp.Application.Model;

namespace RainbowApp.Application.Tasks.Queries
{
    public class GetServiceProviderByMgtNoQuery : IRequest<TblServiceProvider>
    {
        public string MgtNo { get; set; }
    }
}
