using System.Collections;
using System.Collections.Generic;

namespace ISIS.Web.Models
{
    public abstract class Page<T> : IPage<T>
    {

        public int PageNumber { get; private set; }
        public long TotalPages { get; private set; }
        public int ItemsPerPage { get; private set; }
        public long TotalItems { get; private set; }

        private readonly IEnumerable<T> _items;

        public Page(IEnumerable<T> items,
            int pageNumber,
            long totalPages,
            int itemsPerPage,
            long totalItems)
        {
            PageNumber = pageNumber;
            TotalPages = totalPages;
            ItemsPerPage = itemsPerPage;
            TotalItems = totalItems;
            _items = items;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


    }
}