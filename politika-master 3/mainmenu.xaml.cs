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
//using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics;
using System.Threading;


namespace game
{
    /// <summary>
    /// Interakční logika pro mainmenu.xaml
    /// </summary>
    public partial class Mainmenu : Page
    {
        public Player player { get; set; }
        public Task task { get; set; }
        public Arena arena { get; set; }
        public Database database { get; set; } 
        Player item;
        
        public Mainmenu(Player _player, Task _task)
        {
           InitializeComponent();
            task = _task;
           player = _player;


           string lv = player.xp.ToString();
           char player_xp = lv[0];

           int lvl = (int)Char.GetNumericValue(player_xp);

           char lv_bar = lv[1];
           int lvl_bar = (int)Char.GetNumericValue(lv_bar);

           // int lv = player.xp / 100;
           exp_bar_menu.Value = lvl_bar * 10;
           lv_status.Content = lvl;
           label_money.Content = player.money.ToString();

           progress_bar_strenght.Value = player.strenght;
           progress_bar_armor.Value = player.armor;
           progress_bar_dexterity.Value = player.dexterity;
            /*if (arena.achievments == 1)
            {
                achv.Visibility = Visibility.Visible;
                Thread.Sleep(2000);
                arena.achievments = 0;
            }*/
            /*for (int i = 1; i < 3; i++)
             {
                 player.exp[];
             }*/


        }

        /*public Mainmenu(Player player)
        {
            this.player = player;
        }*/

        private void hrad_move(object sender, RoutedEventArgs e)
        {
            
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("hrad.xaml", UriKind.Relative));
            NavigationService.Navigate(new Hrad(player, task));
            //mainFrame.NavigationService.Navigate(new Hrad(player));

            
            //full.Home_but.Visibility = Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("most.xaml", UriKind.Relative));
            NavigationService.Navigate(new Most(player, task));
        }

        private void obchod_move(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Obchod.xaml", UriKind.Relative));
            NavigationService.Navigate(new Obchod(player, task));
        }
        private void inventory_button_Click(object sender, RoutedEventArgs e)
        {
            inventory.Visibility = Visibility.Visible;
            inventory_name.Visibility = Visibility.Visible;            
            inventory_border.Visibility = Visibility.Visible;
            progress_bar_strenght.Visibility = Visibility.Visible;
            progress_bar_dexterity.Visibility = Visibility.Visible;
            progress_bar_armor.Visibility = Visibility.Visible;
            strenght_name.Visibility = Visibility.Visible;
            dexterity_name.Visibility = Visibility.Visible;
            armor_name.Visibility = Visibility.Visible;
            inventory_close_bt.Visibility = Visibility.Visible;
            armor_add_bt.Visibility = Visibility.Visible;
            strengt_add_bt.Visibility = Visibility.Visible;
            dexterity_add_bt.Visibility = Visibility.Visible;
        }   
        

        private void home_exit(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Opravdu chcete ukončit hru? Obsah bude automaticky uložen.","Vypnutí hry", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                MessageBox.Show("Děkujeme za zahrání mé úžasné hry", "Hra byla uložena");
                this.database = new Database("players.db");
                database.SaveMoney(player);
                database.SaveArmor(player);
                database.SaveDexterity(player);
                database.SaveXP(player);
                database.SaveStrenght(player);
                database.SaveDungeonLv(player); ;
                /*string cs = @"URI=file:C:\Users\Kubunacz\Desktop\players.db";
                using var con = new SQLiteConnection(cs);
                con.Open();
                using var cmd = new SQLiteCommand(con);

                //cmd.CommandText = $"INSERT INTO player (nick, xp, strenght, armor, dexterity, money) VALUES ('tomas', {player.exp}, {player.strenght}, {player.armor}, {player.dexterity}, {player.money})";
                cmd.CommandText = $"UPDATE player SET xp = {player.xp}, strenght = {player.strenght}, armor = {player.armor}, dexterity = {player.dexterity}, money = {player.money} WHERE id = 1";
                cmd.ExecuteNonQuery();*/

                App.Current.Shutdown();
            }
            else
            {
                // Do not close the window  
            }
           
        }

        private void Arena_button(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(player.dungeon_lv.ToString());
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Arena.xaml", UriKind.Relative));
            NavigationService.Navigate(new Arena(player, task));
        }    
        private void save_button(object sender, RoutedEventArgs e)
        {
            this.database = new Database("players.db");
            database.SaveMoney(player);
            database.SaveArmor(player);
            database.SaveDexterity(player);
            database.SaveXP(player);
            database.SaveStrenght(player);
            database.SaveDungeonLv(player);
            MessageBox.Show("Hra byla uložena", "Ukládání");

            /*if (MessageBox.Show("Chcete uložit hru?","Uložení hry", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                /*this.database = new Database("players.db");
                database.Update(player);*/

                /*string cs = @"URI=file:C:\Users\Kubunacz\Desktop\players.db";
                using var con = new SQLiteConnection(cs);
                con.Open();
                using var cmd = new SQLiteCommand(con);
                //cmd.CommandText = $"INSERT INTO player (nick, xp, strenght, armor, dexterity, money) VALUES ('tomas', {player.exp}, {player.strenght}, {player.armor}, {player.dexterity}, {player.money})";
                cmd.CommandText = $"UPDATE player SET xp = {player.xp}, strenght = {player.strenght}, armor = {player.armor}, dexterity = {player.dexterity}, money = {player.money} WHERE id = 1";
                cmd.ExecuteNonQuery();
            }
            else
            {
                // Do not close the window  
            }*/

        }

        private void close_bt(object sender, RoutedEventArgs e)
        {
            inventory.Visibility = Visibility.Hidden;
            inventory_name.Visibility = Visibility.Hidden;
            inventory_border.Visibility = Visibility.Hidden;
            progress_bar_strenght.Visibility = Visibility.Hidden;
            progress_bar_dexterity.Visibility = Visibility.Hidden;
            progress_bar_armor.Visibility = Visibility.Hidden;
            strenght_name.Visibility = Visibility.Hidden;
            dexterity_name.Visibility = Visibility.Hidden;
            armor_name.Visibility = Visibility.Hidden;
            inventory_close_bt.Visibility = Visibility.Hidden;
            armor_add_bt.Visibility = Visibility.Hidden;
            strengt_add_bt.Visibility = Visibility.Hidden;
            dexterity_add_bt.Visibility = Visibility.Hidden;
        }

        private void strenght_add(object sender, RoutedEventArgs e)
        {
            if (player.money >= 100)
            {
                if (player.strenght < 100)
                {
                    player.strenght = player.strenght + 2;
                    progress_bar_strenght.Value = player.strenght;
                    player.money = player.money - 100;
                    label_money.Content = player.money;
                }
            }
            else
            {
                MessageBox.Show("Nemáte dostatek peněz!!");
            }
        }
        private void armor_add(object sender, RoutedEventArgs e)
        {
            if (player.money >= 100)
            {
                if (player.armor < 100)
                {
                    player.armor = player.armor + 2;
                    progress_bar_armor.Value = player.armor;
                    player.money = player.money - 100;
                    label_money.Content = player.money;
                }
            }
            else
            {
                MessageBox.Show("Nemáte dostatek peněz!!");
            }
        }
        private void dexterity_add(object sender, RoutedEventArgs e)
        {
            if (player.money >= 100)
            {
                if (player.dexterity < 100)
                {
                    player.dexterity = player.dexterity + 2;
                    progress_bar_dexterity.Value = player.dexterity;
                    player.money = player.money - 100;
                    label_money.Content = player.money;
                }
            }
            else
            {
                MessageBox.Show("Nemáte dostatek peněz!!");
            }
        }
    }
}
