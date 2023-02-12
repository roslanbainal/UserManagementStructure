using Microsoft.EntityFrameworkCore;
using UserManagement.Data;
using UserManagement.Interfaces;
using UserManagement.Models.Entities;

namespace UserManagement.Services
{
    public class EndpointStore : IEndPointStore
    {
        private readonly ApplicationDbContext _dbContext;

        public EndpointStore(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public EndPoints GetEndpoint(RouteData routeData)
        {
            var controllerName = routeData.Values["controller"].ToString();
            var actionName = routeData.Values["action"].ToString();

            return _dbContext.EndPoints.SingleOrDefault(e => e.ControllerName == controllerName && e.ActionName == actionName);
        }
    }
}
