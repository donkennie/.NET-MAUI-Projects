namespace News.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;
using NewsApp.ViewModels;

[ObservableObject]
public abstract partial class ViewModel
{
    public INavigate Navigation { get; init; }

    internal ViewModel(INavigate navigation) => Navigation = navigation;
}