using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Ui.Common.Interfaces;
using Wpf.Ui.Controls;

public class HomeViewModel : INavigationAware 
{
    public void OnNavigatedTo()
    {
    }
    public void OnNavigatedFrom()
    {
    }
}
namespace WpfUIStudy.Pages
{
    public partial class Home : INavigableView<HomeViewModel>
    {
        public HomeViewModel ViewModel { get; }

        public Home()
        {
            InitializeComponent();
        }
    }
}
