﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using News.ViewModels;
using NewsApp.Models;
using NewsApp.Services;
using System.Web;

namespace NewsApp.ViewModels
{
    public partial class HeadlinesViewModel : ViewModel
    {
        private readonly INewsService newsService;

        [ObservableProperty]
        private NewsResult currentNews;

        public HeadlinesViewModel(INewsService newsService, INavigate navigation) : base(navigation)
        {
            this.newsService = newsService;
        }

        public async Task Initialize(string scope) => await Initialize(scope.ToLower() switch
        {
            "local" => NewsScope.Local,
            "global" => NewsScope.Global,
            "headlines" => NewsScope.Headlines,
            _ => NewsScope.Headlines
        });

        public async Task Initialize(NewsScope scope)
        {
            currentNews = await newsService.GetNews(scope);
        }

        [RelayCommand]
        public async Task ItemSelected(object selectedItem)
        {
            var selectedArticle = selectedItem as Article;
            var url = HttpUtility.UrlEncode(selectedArticle.Url);
            await Navigation.NavigateTo($"articleview?url={url}");
        }
    }
    
}
