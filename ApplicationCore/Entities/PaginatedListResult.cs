using System;
using System.Collections.Generic;

namespace ContactManagement.ApplicationCore.Entities
{
    public class PaginatedListResult<T> where T : class, IEntityBase, new()
    {
        private PaginatedListResult()
        {}

        private PaginatedListResult(IList<T> source, bool hasNext, bool hasPrevious, int count, int pageCount, int currentPage, int pageSize) : this()
        {
            HasNext = hasNext;
            HasPrevious = hasPrevious;
            Count = count;
            PageCount = pageCount;
            CurrentPage = currentPage;
            PageSize = pageSize;
            Entities.AddRange(source);
        }
        
        public bool HasNext { get; }
        public int PageCount { get; }
        public int PageSize { get; }
        public int CurrentPage { get; }
        public bool HasPrevious { get; }
        public int Count { get; }
        public List<T> Entities { get; private set; }

        public static PaginatedListResult<T> Create(IList<T> source, int pageSize, int skip, int count)
        {
            var hasNext = skip + pageSize < count;
            var hasPrevious = skip > 0;
            var pageCount = (int)Math.Ceiling((double)count / pageSize);
            var current = (int)Math.Ceiling((double)skip / pageSize) + 1;
            return new PaginatedListResult<T>(source, hasNext, hasPrevious, count, pageCount, current, pageSize);
        }
    }
}
