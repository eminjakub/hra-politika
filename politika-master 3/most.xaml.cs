using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace game
{
    /// <summary>
    /// Interakční logika pro most.xaml
    /// </summary>
    public partial class Most : Page
    {
        Player player { get; set; }
        Task task { get; set; }
        public Most(Player _player, Task _task)
        {
            this.task = _task;
            this.player = _player;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dealeros_button_click_shop(object sender, RoutedEventArgs e)
        {
            dealeros_velky_img.Visibility = Visibility.Hidden;
            dealeros_window.Visibility = Visibility.Visible;
            dealeros_frame.Visibility = Visibility.Visible;
            dealeros_close_button.Visibility = Visibility.Visible;
            dealeros_img.Visibility = Visibility.Visible;
            dealeros_close_button_img.Visibility = Visibility.Visible;
        }
        private void Get_home(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("./task_file/task_page.xaml", UriKind.Relative));
            NavigationService.Navigate(new Mainmenu(player, task));
        }
        private void dealeros_button_click_close(object sender, RoutedEventArgs e)
        {
            dealeros_velky_img.Visibility = Visibility.Visible;
            dealeros_window.Visibility = Visibility.Hidden;
            dealeros_frame.Visibility = Visibility.Hidden;
            dealeros_close_button.Visibility = Visibility.Hidden;
            dealeros_img.Visibility = Visibility.Hidden;
            dealeros_close_button_img.Visibility = Visibility.Hidden;


        }

    }
}
