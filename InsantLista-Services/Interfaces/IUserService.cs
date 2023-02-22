using System;
using InstantLista_ClassLibrary;

namespace InsantLista_Services.Interfaces
{
	public interface IUserService
	{
        public Task<UserDto> GetUser(int userId);
    }
}

