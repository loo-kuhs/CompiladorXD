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
using MaterialDesignThemes.Wpf;
using System.Text.RegularExpressions;
using TSimbolos;
using System.IO;
using Microsoft.Win32;

namespace WpfApp1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TSimbolosM Tsimbols = new TSimbolosM();

        public MainWindow()
        {
            InitializeComponent();
            Tsimbols.Tokens();
        }

        #region ANALIZADOR SINTACTICO

        public void SintacticAnalizar()
        {
            TokensData.Items.Clear();
            String[] linea = new String[txtWriter.LineCount];

            if (txtWriter.Text != null)
            {
                for (int i = 0; i < linea.Length; i++)
                {
                    linea[i] = txtWriter.GetLineText(i);

                    if (linea[i] != null)
                    {
                        if (Regex.IsMatch(linea[i], @"^(>int|>Entero)\s+\w+(\s+:\s+\d)*;(|\s)$"))
                        {
                            PrintTokens(">int", i, linea[i].ToString());
                        }
                        else if (Regex.IsMatch(linea[i], @"^(>double|>decimal)\s+\w+(\s+:\s+\d+\.+\d)*;(|\s)$"))
                        {
                            PrintTokens(">double", i, linea[i].ToString());
                        }
                        else if (Regex.IsMatch(linea[i], @"^>string|>texto\s+[a-z](1,15)(\s+:\s+[a-z](1,15)')*;$"))
                        {
                            PrintTokens(">string", i, linea[i].ToString());
                        }
                        else if (Regex.IsMatch(linea[i], @"^>bool|>Booleano\s+[a-z](1,15)(\s+:\s+(true|false))*;$"))
                        {
                            PrintTokens(">bool", i, linea[i].ToString());
                        }
                        else if (Regex.IsMatch(linea[i], @"<<*.*>>+[\r\n]$"))
                        {
                            PrintTokens("<<", i, linea[i].ToString());
                            PrintTokens(">>", i, linea[i].ToString());
                        }
                        else if (Regex.IsMatch(linea[i], @"[a-z]\s+:+\s[a-z]|(\w)*\s\+\s(\w)*|\d(0,32000)*;+[\r\n]$"))
                        {
                            PrintTokens(":", i, linea[i].ToString());
                        }
                        else if (Regex.IsMatch(linea[i], @"^{+[\r\n]$"))
                        {
                            PrintTokens("{", i, linea[i].ToString());
                        }
                        else if (Regex.IsMatch(linea[i], @"^}|}+[\r\n]$"))
                        {
                            PrintTokens("}", i, linea[i].ToString());
                        }
                        else if (Regex.IsMatch(linea[i], @">si\(\w+\s(<|>|<:|>:|::|!:)\s+\w+\)\s\{+[\r\n]$"))
                        {
                            PrintTokens(">si", i, linea[i].ToString());
                            PrintTokens("{", i, linea[i].ToString());
                            PrintTokens("(", i, linea[i].ToString());
                            PrintTokens(")", i, linea[i].ToString());
                        }
                        else if (Regex.IsMatch(linea[i], @">sino\s*\{+[\r\n]$"))
                        {
                            PrintTokens(">sino", i, linea[i].ToString());
                            PrintTokens("{", i, linea[i].ToString());
                        }
                        else if (Regex.IsMatch(linea[i], @">print\((\w*)|'\w*'\);$"))
                        {
                            PrintTokens(">print", i, linea[i].ToString());
                        }
                        else if (Regex.IsMatch(linea[i], @">class\s+\w+\s\{+[\r\n]$"))
                        {
                            PrintTokens(">class", i, linea[i].ToString());
                            PrintTokens("{", i, linea[i].ToString());
                        }
                        else if (Regex.IsMatch(linea[i], @">func\s+\w+\s\(+(\s?|\w)+\)\{+[\r\n]$"))
                        {
                            PrintTokens(">func", i, linea[i].ToString());
                            PrintTokens("(", i, linea[i].ToString());
                            PrintTokens(")", i, linea[i].ToString());
                        }
                    }
                }
            }
        }
        #endregion

        #region  IMPRIMIR TOKENS EN LISTVIEW
        public void PrintTokens(string token, int i, string linea)
        {
            Tsimbols.datos.Clear();
            dynamic data = new List<Compl>();
            data = Tsimbols.BuscarToken(token, i, linea);
            foreach (var x in data)
            {
                TokensData.Items.Add(x);
            }
        }
        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OnFocus(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            SolidColorBrush colorBrush = new SolidColorBrush(Color.FromArgb(80, 255, 255, 255));
            btn.Background = colorBrush;
        }

        private void OnFocusR(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            SolidColorBrush colorBrush = new SolidColorBrush(Color.FromArgb(80, 255, 255, 255));
            btn.Background = colorBrush;
        }

        private void LeaveFocus(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            btn.Background = Brushes.Transparent;
        }

        private void btnMax_Click(object sender, RoutedEventArgs e)
        {
            var iMin = new PackIcon { Kind = PackIconKind.WindowRestore };
            var iMax = new PackIcon { Kind = PackIconKind.WindowMaximize };

            if (WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
                btnMax.Content = iMin;
            }
            else
            {
                btnMax.Content = iMax;
                this.WindowState = WindowState.Normal;
            }
        }

        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Minimized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Minimized;
            }
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = " Abrir archivo      -        Compilador";
            openFileDialog.Filter = "Archivos CBuz#(*.Buz)|*.Buz";

            if (openFileDialog.ShowDialog() == true)
                txtWriter.Text = File.ReadAllText(openFileDialog.FileName);

        }

        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = " Abrir archivo      -        CompiladorBuz ";
            saveFileDialog.Filter = "Archivos CBuz#(*.Buz)|*.Buz";
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, txtWriter.Text);
        }

        private void Proof(Object sender, ScrollChangedEventArgs e)
        {
            txtLines.ScrollToVerticalOffset(e.VerticalOffset);
            txtWriter.ScrollToVerticalOffset(e.VerticalOffset);
        }

        private void txtWriter_TextChanged(object sender, TextChangedEventArgs e)
        {
            SintacticAnalizar();
            var linIzq = txtWriter.LineCount;
            txtLines.Text = " ";
            for (var i = 1; i <= linIzq; i++)
                // Indentar el texto a la derecha
                txtLines.Text += i.ToString("0").PadLeft(4) + "\r";
        }

        private void Mostrar_Click(object sender, RoutedEventArgs e)
        {
            Views.ViewTokens viewTokens = new Views.ViewTokens();
            this.Hide();
            viewTokens.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
