using MediatR;
using System.Collections.Generic;

namespace LogApp.Application.Businesses.Queries.GetBusinessesList
{
    public class GetBusinessesListQuery : IRequest<List<BusinessVm>>
    {
    }
}
