using System;
using System.Collections.Generic;
using System.Text;

namespace game
{
    public class Fight
    {
        public Player player;
        public Enemy enemy;
        public Arena arena;
        public Fullgame fullgame;
        public int result { get; set; }
        public int dmg_enemy { get; set; }
        //public int dungeon_lv { get; set; } = 1;
        public Fight(Player _player)
        {
            this.player = _player;
            this.enemy = new Enemy();
            
            
        }     
        public int Fight_in_procces()
        {
            enemy.health = 10;
            player.strenght = 1;
            /*while (enemy.health >= 0)
            {
                enemy.health = enemy.health - player.strenght;
            }*/
            return result = 1;
                        
        }
        public void Fight_void()
        {
            enemy.health = 100;
            player.health = 100;

            enemy.strenght = 3;
            enemy.armor = 3;            
            enemy.dexterity = 1;
            Random random = new Random();
            //int rnd_enemy = random.Next(45, 65);
            int rnd_player = random.Next(1, 100);
            
            dmg_enemy = (enemy.strenght * enemy.armor + enemy.dexterity)*player.dungeon_lv;
            int dmg_player = player.strenght * player.armor + player.dexterity;
            
            if (dmg_enemy > dmg_player)
            {
                result = 2;
            }
            else
            {
                result = 1;
                
            }
                /*while (enemy.health >= 0)
                {
                   enemy.health = enemy.health - player.strenght;
                   player.health = player.health - enemy.strenght;

                }*/

                
            if (result == 1)
            {
                player.money = player.money +100;
            }
            else{

            }


            return;
            
        }

    }
}
