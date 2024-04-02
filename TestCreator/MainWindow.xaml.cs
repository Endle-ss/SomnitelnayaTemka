using Microsoft.Win32;
using System;
using System.Net.Sockets;
using System.Windows;
using TestCreator;

namespace TestGenerator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartClick(object sender, RoutedEventArgs e)
        {
        
        }

        private void RegClick(object sender, RoutedEventArgs e)
        {
            Paroll.Visibility = Visibility.Visible;
        }

        private void PasswordTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            Paroll.Visibility = Visibility.Visible;

            if (Paroll.Text == "Попъердоноле")
            {
                Regnulsa registred = new Regnulsa(Paroll);
                registred.Show();
                Close();
            }
            else
            {
                Paroll.Text = "Мимо ";
            }

        }
    }
}
