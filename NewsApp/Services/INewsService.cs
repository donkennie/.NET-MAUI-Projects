﻿using News.Models;namespace NewsApp.Services
{
    public interface INewsService
    {
        public Task<NewsResult> GetNews(NewsScope scope);
    }
}
