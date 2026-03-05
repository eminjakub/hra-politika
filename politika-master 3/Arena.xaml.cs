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
using System.Diagnostics;

namespace game
{
    /// <summary>
    /// Interakční logika pro Arena.xaml
    /// </summary>
    public partial class Arena : Page
    {
        Player player { get; set; }
        public int achievments { get; set; } = 0;
        Task task { get; set; }
        //Enemy enemy { get; set; }
        Fight fight { get; set; }
        public Arena(Player _player, Task _task)
        {
            this.task = _task;
            this.player = _player;
            this.fight = new Fight(_player);
            InitializeComponent();
        }

        private void Arena_button(object sender, RoutedEventArgs e)
        {
            flakanec_img_postava.Visibility = Visibility.Hidden;

            flakanec_block.Visibility = Visibility.Visible;
            flakanec_img.Visibility = Visibility.Visible;
            dialog_block.Visibility = Visibility.Visible;
            start_fight.Visibility = Visibility.Visible;
            dialog_close.Visibility = Visibility.Visible;
            //MessageBox.Show(fight.result.ToString());
        }

        private void Fight_start(object sender, RoutedEventArgs e)
        {
            fight.Fight_void();
            dialog_block.Visibility = Visibility.Hidden;
            start_fight.Visibility = Visibility.Hidden;

            flakanec_ruka.Visibility = Visibility.Visible;
            dialog_after.Visibility = Visibility.Visible;
            if (fight.result == 1)
            {
                player.money = player.money + 100;
                player.dungeon_lv++;
                //MessageBox.Show(Fight.enemy)
                dialog_after.Text = "Ty šmejde!!! Já si tě najdu jen se neboj. Dostaneš takovej FLÁKANEC že tě ani tvá vlastní matka nepozná. Stejně jsi jenom špína. Já tu bojuji za českou  vlast!!!!!";
                achievments = 1;
            }
            else
            {
                dialog_after.Text = "Tak to pšiznej chcípáku, nyc nejsy! Žádné vychování ty nevlastenecké hovádko. Já jsem praví czech";
                
            }
            

            
            //MessageBox.Show(fight.result.ToString());
        }

        private void Dialog_close(object sender, RoutedEventArgs e)
        {
            flakanec_img_postava.Visibility = Visibility.Visible;

            dialog_after.Visibility = Visibility.Hidden;
            flakanec_ruka.Visibility = Visibility.Hidden;
            flakanec_block.Visibility = Visibility.Hidden;
            flakanec_img.Visibility = Visibility.Hidden;
            dialog_block.Visibility = Visibility.Hidden;
            start_fight.Visibility = Visibility.Hidden;
            dialog_close.Visibility = Visibility.Hidden;

        }

        private void Get_home(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("mainmenu.xaml", UriKind.Relative));
            NavigationService.Navigate(new Mainmenu(player, task));
        }
    }
}
