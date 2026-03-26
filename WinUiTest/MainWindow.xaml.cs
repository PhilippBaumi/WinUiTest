using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUiTest
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public ViewModel ViewModel { get; } = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void AddToList(object sender, RoutedEventArgs e)
        {
            DateTime dt = ViewModel.SelectedDate.DateTime;
            string date = dt.ToString("dd.MM.yyyy");
            if (ViewModel.Dates.Contains(date))
            {
                await ShowDialog(this.Content.XamlRoot, "Datum vorhanden", "Datum "+date+" bereits vorhaden", "OK");
                return;
            }
           ViewModel.Dates.Add(date);
        }

        private async Task ShowDialog(XamlRoot xamlRoot, string title, string content, string buttonText)
        {
          ContentDialog dialog = new ContentDialog
          {
              XamlRoot = xamlRoot,
              Title = title,
              Content = content,
              CloseButtonText = buttonText
          };
           await dialog.ShowAsync();
        }

        private async void SelectedItem(object sender, SelectionChangedEventArgs e)
        {
            string? date = ViewModel.SelectedText;
            if (date != null)
            {
                await ShowDialog(this.Content.XamlRoot, "Gewähltes Datum", "Du hast " + date + " gewählt! ", "OK");
            }
            return;
        }
    }
}
