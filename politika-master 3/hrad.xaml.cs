using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace game
{
    /// <summary>
    /// Interakční logika pro hrad.xaml
    /// </summary>
    public partial class Hrad : Page
    {
        

        public Player player { get; set; }
        public Task task { get; set; }
        public Database database { get; set; }


        public Hrad(Player _player, Task _task)
        {
            this.task = _task;
            this.player = _player;
            
            InitializeComponent();
            //label_money.Content = player.money.ToString();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        int entry = 0;
        
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (entry == 0)
            {
                this.database = new Database("tasks.db");

                Random random = new Random();
                task.task_id = random.Next(0, 12);
                //using SQLiteDataReader rdr = cmd.ExecuteReader();

                /*task.Task_name = database.Task_name(task.task_id);
                task.task_description = database.Task_description(task.task_id);
                task.Task_lenght = database.Task_time(task.task_id);
                task.Task_money = database.Task_money(task.task_id);
                task.Task_xp = database.Task_xp(task.task_id); */

                task.Task_name = database.Taskddd(task.task_id)[0].task_name;
                task.task_description = database.Taskddd(task.task_id)[0].task_description;
                task.Task_lenght = database.Taskddd(task.task_id)[0].task_time;
                task.Task_money = database.Taskddd(task.task_id)[0].money;
                task.Task_xp = database.Taskddd(task.task_id)[0].xp;

                //task.Task_money = database.Taskddd(task.task_id)[0];


                entry = +1;

            }
            

            //MessageBox.Show(Task_name);
            //MessageBox.Show(task_description);
            //MessageBox.Show(Task_lenght);
            task_name_label.Content = task.Task_name;
            task_description_label.Text = task.task_description;
            task_lenght_label.Content = $"Délka: {Int32.Parse(task.Task_lenght)*10} sekund";
            task_money_label.Content = $"Peníze: {task.Task_money}";

            task_name_label.Visibility = Visibility.Visible;
            task_description_label.Visibility = Visibility.Visible;
            task_lenght_label.Visibility = Visibility.Visible;
            quest_box.Visibility = Visibility.Visible;
            quest_milos.Visibility = Visibility.Visible;
            frame.Visibility = Visibility.Visible;
            close_button.Visibility = Visibility.Visible;
            close_button_img.Visibility = Visibility.Visible;
            task_1.Visibility = Visibility.Visible;
            task_money_label.Visibility = Visibility.Visible;
            

            milos_button.Visibility = Visibility.Hidden;
            milos_button_img.Visibility = Visibility.Hidden;


            

        }


        private void milos_quest_close(object sender, RoutedEventArgs e)
        {

            quest_box.Visibility = Visibility.Hidden;
            quest_milos.Visibility = Visibility.Hidden;
            frame.Visibility = Visibility.Hidden;
            close_button.Visibility = Visibility.Hidden;
            close_button_img.Visibility = Visibility.Hidden;
            task_1.Visibility = Visibility.Hidden;
            task_money_label.Visibility = Visibility.Hidden;

            milos_button.Visibility = Visibility.Visible;
            milos_button_img.Visibility = Visibility.Visible;

            task_name_label.Visibility = Visibility.Hidden;
            task_description_label.Visibility = Visibility.Hidden;
            task_lenght_label.Visibility = Visibility.Hidden;
        }
        private void get_home(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("mainmenu.xaml", UriKind.Relative));
            NavigationService.Navigate(new Mainmenu(player, task));

        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Fullgame mainMenuPage = fullh;
            //mainMenuPage.Content = new Task_page(this.fullh);
            //NavigationService.Navigate(new Task_page(player));

            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("./task_file/task_page.xaml", UriKind.Relative));
            NavigationService.Navigate(new Task_page(player, task));

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
