using System;
using InstantLista_ClassLibrary.DataTransferObjects;

namespace InsantLista_Services.Interfaces
{
	public interface IAuthenticationService
	{
        Task<TokenJWTDto> Authenticate(string userName, string passWord);

    }
}

