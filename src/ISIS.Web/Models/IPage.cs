using System.Collections.Generic;

namespace ISIS.Web.Models
{
    public interface IPage<T> : IEnumerable<T>
    {

        int PageNumber { get; }
        long TotalPages { get; }
        int ItemsPerPage { get; }
        long TotalItems { get; }

    }
}
