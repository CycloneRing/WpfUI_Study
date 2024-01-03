using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;
using Wpf.Ui.Controls.Interfaces;
using Wpf.Ui.Mvvm.Contracts;
using Wpf.Ui.Mvvm.Interfaces;
using Wpf.Ui.TaskBar;
using WpfUIServices = Wpf.Ui.Mvvm.Services;

namespace WpfUIStudy
{
    public partial class Dashboard : INavigationWindow
    {
        private readonly IThemeService      _themeService;
        private readonly ITaskBarService    _taskBarService;
        private readonly INavigationService _navigationService;

        public Frame GetFrame() => RootFrame;
        public INavigation GetNavigation() => RootNavigation;
        public bool Navigate(Type pageType) => RootNavigation.Navigate(pageType);
        public void SetPageService(IPageService pageService) => RootNavigation.PageService = pageService;
        public void ShowWindow() => Show();
        public void CloseWindow() => Close();

        // Initializer
        public Dashboard()
        {
            _themeService = new WpfUIServices.ThemeService();
            _taskBarService = new WpfUIServices.TaskBarService();
            _navigationService = new WpfUIServices.NavigationService();

            InitializeComponent();
        }

        // Events
        private void ThemeSwitchClick(object sender, RoutedEventArgs e)
        {
            _themeService.SetTheme(_themeService.GetTheme() == ThemeType.Dark ? ThemeType.Light : ThemeType.Dark);
        }
        private void DashboardLoaded(object sender, RoutedEventArgs e)
        {
            // Set System Accent Color
            _themeService.SetSystemAccent();

            // Load Default Page
            DefaultNavigation.RaiseEvent(new RoutedEventArgs(NavigationItem.ClickEvent));
            Navigate(typeof(Pages.Home));
        }
    }
}
