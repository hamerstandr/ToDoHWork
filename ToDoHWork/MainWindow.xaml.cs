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

namespace ToDoHWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly Database database = new Database();
        internal Database Database => database;
        public MainWindow()
        {
            InitializeComponent();
            this.Closing += MainWindow_Closing;
            List1.ItemsSource = database.Data.Items;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Database.Save();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Database.Add(Text1.Text);
            List1.Items.Refresh();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            database.Save();
        }

        private void DelItem_Click(object sender, RoutedEventArgs e)
        {
            Task item = (Task)(sender as Button).DataContext;
            database.Data.Items.Remove(item);
            List1.Items.Refresh();
        }
    }
}
