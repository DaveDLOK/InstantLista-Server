using System;
using InstantLista_ClassLibrary;

namespace InsantLista_Services.Interfaces
{
	public interface IAuthenticationService
	{
        Task<TokenJWTDto> Authenticate(string userName, string passWord);
        Task<TokenJWTDto> Refresh(string bearertoken, string refreshToken);

    }
}

