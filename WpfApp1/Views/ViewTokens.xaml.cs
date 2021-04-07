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
using System.Windows.Shapes;
using TSimbolos;


namespace WpfApp1.Views
{
    /// <summary>
    /// Lógica de interacción para ViewTokens.xaml
    /// </summary>
    public partial class ViewTokens : Window
    {
        public ViewTokens()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void OnFocusR(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            SolidColorBrush solidColor = new SolidColorBrush(Color.FromArgb(120, 255, 17, 0));
            btn.Background = solidColor;
        }

        private void LeaveFocus(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            btn.Background = Brushes.Transparent;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TSimbolosM tokn = new TSimbolosM();
            tokn.Tokens();
            var datos = tokn.ObtenerTokens();

            foreach (var x in datos)
            {
                TokensShow.Items.Add(x);
            }
        }
    }
}
