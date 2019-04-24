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
using System.Data.Entity;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Models.User user = new Models.User();

        public MainWindow()
        {
            InitializeComponent();
            uxSubmit.IsEnabled.Equals(false);
            uxContainer.DataContext = user;
            var sample = new SampleEntities();

            sample.Users.Load();

            uxList.ItemsSource = sample.Users.Local;
        }

        public override void EndInit()
        {
            base.EndInit();

        }

        private void UxSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("New password is:" + uxPassword.Text);

            var window = new SecondWindow();
            Application.Current.MainWindow = window;
            Close();
            window.Show();
        }

        private void CheckForNull(object sender, TextChangedEventArgs e)
        {
            //Both fields empty -> uxSubmit is disabled
            //Only one field has text->uxSubmit is disabled
            if (String.IsNullOrEmpty(uxName.Text) || String.IsNullOrEmpty(uxPassword.Text))
            {
                uxSubmit.IsEnabled = false;
                return;
            }
            
            if (!String.IsNullOrEmpty(uxName.Text) && !String.IsNullOrEmpty(uxPassword.Text))
            {
                uxSubmit.IsEnabled = true;
                return;
            }
        }
    }
}
