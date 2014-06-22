using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class EnemyManager
    {
        private Enemy enemy = new Enemy();
        private Random random = new Random();
        private Player player;
        private GameWindow main;
        private Combat combat;

        private int index;

        public void UpdateClass(GameWindow gm, Combat c, Player p)
        {
            main = gm;
            combat = c;
            player = p;
            UpdateGame();            
        }

        public void UpdateGame()
        {
            enemy.UpdateClass(main, combat);
            combat.SetEnemy(enemy);
        }

        public Enemy GetEnemy()
        {
            return enemy;
        }

        public int GetIndex()
        {
            return index;
        }

        public Enemy FindMonster(int x)
        {
            if (x <= 1)
            {
                return GetMonster(random.Next(3));
            }
            else if (x <= 2)
            {
                return GetMonster(3 + random.Next(3));
            }
            else if (x <= 3)
            {
                return GetMonster(3 + random.Next(6));
            }
            else if (x <= 4)
            {
                return GetMonster(6 + random.Next(6));
            }
            else if (x <= 5)
            {
                return GetMonster(9 + random.Next(6));
            }
            else
            {
                return GetMonster(12 + random.Next(7));
            }
        }

        public Enemy GetMonster(int m)
        {
            enemy = SpawnMonster(m);
            return enemy;
        }

        public Enemy SpawnMonster(int m)
        {
            index = m;
            // LEVEL, NAME, HP, AP, DEF, EXP GAIN, COMBAT-TYPE, STORY-TYPE
            switch (m)
            {
                case 0:
                    return new Enemy(1, "Rat", 18, 16, 3, 24); //player at 50, 4, 1
                case 1:
                    return new Enemy(1, "Bat", 25, 18, 3, 27, MONSTERTYPE.FLYER);
                case 2:
                    return new Enemy(1, "Blob", 20, 18, 3, 25);


                case 3:
                    return new Enemy(2, "Death Hornet", 50, 20, 5, 40, MONSTERTYPE.FLYER); //player at 75, 5, 2
                case 4:
                    return new Enemy(2, "Giant Spider", 55, 19, 5, 37);
                case 5:
                    return new Enemy(2, "Giant Snake", 50, 19, 5, 35);


                case 6:
                    return new Enemy(3, "Ogre", 120, 30, 9, 55);  //player at 103, 7, 3
                case 7:
                    return new Enemy(3, "Soldier", 95, 28, 9, 53);
                case 8:
                    return new Enemy(3, "Imp", 130, 26, 9, 60, MONSTERTYPE.FLYER);


                case 9:
                    return new Enemy(4, "Zombie", 90, 30, 10, 220, MONSTERTYPE.MAGICAL); //player at 135, 9, 5
                case 10:
                    return new Enemy(4, "Assassin", 95, 32, 10, 180, MONSTERTYPE.MAGICAL);
                case 11:
                    return new Enemy(4, "Chimera", 100, 32, 10, 225, MONSTERTYPE.FLYER);


                case 12:
                    return new Enemy(5, "Mage", 155, 40, 12, 340, MONSTERTYPE.MAGICAL); //player at 171, 11, 7
                case 13:
                    return new Enemy(5, "Daemon", 160, 42, 12, 350, MONSTERTYPE.MAGICAL);
                case 14:
                    return new Enemy(5, "Necromancer", 140, 42, 12, 330, MONSTERTYPE.MAGICAL);



                case 15:
                    return new Enemy(6, "Beholder", 200, 49, 18, 535, MONSTERTYPE.MAGICAL); //player at 214, 15, 9
                case 16:
                    return new Enemy(6, "Pyromancer", 210, 50, 18, 543, MONSTERTYPE.MAGICAL);
                case 17:
                    return new Enemy(6, "Vampyre", 220, 48, 18, 540, MONSTERTYPE.FLYER);
                case 18:
                    return new Enemy(6, "Elite", 250, 52, 20, 640, MONSTERTYPE.MAGICAL);



                case 19:
                    return new Enemy(8, "Dark Wizard General", 400, 28, 12, 700, MONSTERTYPE.MAGICAL, MONSTERTIER.BOSS);
                case 20:
                    return new Enemy(10, "Death Incarnate", 600, 52, 25, 1500, MONSTERTYPE.FLYER, MONSTERTIER.FINALBOSS); // 600 25
                default:
                    return new Enemy(0, "Default", 0, 0, 0, 0);
            }
        }
        
        public void GetRandomEncounter()
        {
            if ((random.Next(100)) > 50)
            {
                enemy = FindMonster(player.GetLevel());
                UpdateGame();
                main.MonsterEncounter();
            }

        }

        public void GetBoss()
        {
            if (player.GetProgress() == 21)
            {
                enemy = GetMonster(19);
            }

            else if (player.GetProgress() == 41)
            {
                enemy = GetMonster(20);
            }
            main.MonsterEncounter();
        }

    }
}
