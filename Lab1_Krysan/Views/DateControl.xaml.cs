using Lab1_Krysan.ViewModels;
using System.Windows.Controls;


namespace Lab1_Krysan.Views
{
    /// <summary>
    /// Interaction logic for DateControl.xaml
    /// </summary>
    public partial class DateControl : UserControl
    {
        public DateControl()
        {
            InitializeComponent();
            DataContext = new DateViewModel();
        }
    }
}
