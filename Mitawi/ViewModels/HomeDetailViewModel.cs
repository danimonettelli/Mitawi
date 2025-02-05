﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mitawi.Models;
using Mitawi.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mitawi.ViewModels
{
    public partial class HomeDetailViewModel : MyBaseViewModel
    {
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        private Daily myDaily;

        [ObservableProperty]
        private List<Daily> days;

        public HomeDetailViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        [RelayCommand]
        private async Task GoBack()
        {
            await Task.Delay(300).ConfigureAwait(true);
            _navigationService.GoBack();
        }

        public override void Initialize(object parameter)
        {
            if (parameter == null)
            {
                Days = new List<Daily>();
            }
            else
            {
                Days = parameter as List<Daily>;

                // Get tomorrow's weather
                MyDaily = Days.ElementAt(1);
            }
        }

    }
}