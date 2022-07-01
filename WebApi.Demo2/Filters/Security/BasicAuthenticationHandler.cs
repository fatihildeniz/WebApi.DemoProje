using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using WebApi.Core.DTOs;
using WebApi.Core.Entities;
using WebApi.Core.Services;

namespace WebApi.Demo2.Filters.Security
{
    public class BasicAuthenticationHandler : AuthenticationHandler<BasicAuthenticationOption>
    {
        private readonly IUserAuthenticationService _service;
        public BasicAuthenticationHandler(IOptionsMonitor<BasicAuthenticationOption> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, Core.Services.IUserAuthenticationService service) : base(options, logger, encoder, clock)
        {
            _service = service;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return await Task.FromResult(AuthenticateResult.NoResult());
            }

            if (!AuthenticationHeaderValue.TryParse(Request.Headers["Authorization"], out AuthenticationHeaderValue headerValue))
            {
                return await Task.FromResult(AuthenticateResult.NoResult());
            }

            if (!headerValue.Scheme.Equals("Basic", StringComparison.OrdinalIgnoreCase))
            {
                return await Task.FromResult(AuthenticateResult.NoResult());
            }
            byte[] headerValueBytes = Convert.FromBase64String(headerValue.Parameter);
            string namePassword = Encoding.UTF8.GetString(headerValueBytes);
            var values = namePassword.Split(":");
            string name = values[0];
            string password = values[1];

            List<UserAuthentication> user = _service.Get(x=>x.UserName == name && x.Password == password );

            Claim[] claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, user[0].UserName),
                new Claim(ClaimTypes.NameIdentifier,user[0].ID.ToString()),
                new Claim(ClaimTypes.Role, user[0].UserRole)
            };

            ClaimsIdentity identity = new ClaimsIdentity(claims, Scheme.Name);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            AuthenticationTicket ticket = new AuthenticationTicket(principal, Scheme.Name);
            return await Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}
