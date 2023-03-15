using System;
using InstantLista_ClassLibrary;

namespace InsantLista_Services.Interfaces
{
	public interface INewsService
	{
        public Task<IEnumerable<NewsDto>> GetNews();
    }
}

