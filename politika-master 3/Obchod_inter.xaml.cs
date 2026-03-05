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
    /// Interakční logika pro Obchod_inter.xaml
    /// </summary>
    
    public partial class Obchod_inter : Page
    {
        public Player player { get; set; }
        public Task task { get; set; }
        public Obchod_inter(Player _player, Task _task)
        {
            this.player = _player;
            this.task = _task;
            InitializeComponent();
        }
        private void Get_home(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("./task_file/task_page.xaml", UriKind.Relative));
            NavigationService.Navigate(new Mainmenu(player, task));
        }
    }
}
