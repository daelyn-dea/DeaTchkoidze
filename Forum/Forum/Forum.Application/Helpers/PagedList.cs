// Copyright (C) TBC Bank. All Rights Reserved.

namespace Forum.Application.Helpers
{
    public class PagedList<T>
    {
        public List<T>? Items { get; set; }
        public T? Item { get; set; }
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }

        public PagedList(List<T>? items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = Math.Max((int)Math.Ceiling(count / (double)pageSize), 1);
            Items = items;

        }

        public PagedList(T? item, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = Math.Max((int)Math.Ceiling(count / (double)pageSize), 1);
            Item = item;
        }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
    }
}
