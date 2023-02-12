using UserManagement.Models.Entities;

namespace UserManagement.Interfaces
{
    public interface IEndPointStore
    {
        EndPoints GetEndpoint(RouteData routeData);
    }
}
