﻿namespace Domain.Shared.Pagination
{
    public class QueryParameters
    {
        private const int MaxPageSize = 100;
        private int _pageSize = 10;

        public int PageNumber { get; set; } = 1;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }

        public string? SearchTerm { get; set; }
        public string? OrderBy { get; set; }
        public bool IsDescending { get; set; } = false;
    }
}
