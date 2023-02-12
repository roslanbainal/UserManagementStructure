using Microsoft.AspNetCore.Authorization;
using UserManagement.Interfaces;

namespace UserManagement.Security.Authorization
{
    public class DynamicEndpointAuthorizationHandler : AuthorizationHandler<DynamicEndpointAuthorizationRequirement>
    {
        private readonly IEndPointStore _endpointStore;
        private readonly IHttpContextAccessor? _httpContextAccessor;

        public DynamicEndpointAuthorizationHandler(IEndPointStore endpointStore, IHttpContextAccessor? httpContextAccessor)
        {
            _endpointStore = endpointStore;
            _httpContextAccessor = httpContextAccessor;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, DynamicEndpointAuthorizationRequirement requirement)
        {
            var endpoint = _endpointStore.GetEndpoint(_httpContextAccessor?.HttpContext?.GetRouteData());

            if (endpoint == null)
            {
                context.Fail();
            }
            else
            {
                endpoint.ApplicationRoles.Select(x => x.Id).ToList().ForEach(r =>
                {
                    if (context.User.IsInRole(r.ToString()))
                    {
                        context.Succeed(requirement);
                    }
                });
            }

        }
    }
}
