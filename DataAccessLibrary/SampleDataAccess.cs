using System;
using Microsoft.Extensions.Caching.Memory;

namespace DataAccessLibrary
{
	public class SampleDataAccess
	{
		public readonly IMemoryCache _memoryCache;

		public SampleDataAccess(IMemoryCache memoryCache)
		{
			_memoryCache = memoryCache;
		}

		public async Task<List<LibraryModel>> GetBooksCache()
		{
			List<LibraryModel> books;

			books = _memoryCache.Get<List<LibraryModel>>("books");

			if(books is null)
            {
				books = new()
				{
					new LibraryModel { BookName = "powerless", Author = "lauren" },
					new LibraryModel {BookName = "midnight library", Author = "matt"},
					new LibraryModel { BookName = "king of greed", Author = "ana"}
				};

				await Task.Delay(3000);

				_memoryCache.Set("books", books, TimeSpan.FromMinutes(1));
            };

            return books;
		}
	}
}