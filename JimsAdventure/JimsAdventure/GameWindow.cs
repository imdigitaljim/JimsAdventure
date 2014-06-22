using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace RPG
{
    public partial class GameWindow : Form
    {
        private Story story = new Story();
        private Timer gameTimer = new Timer();
        private TitleWindow title = new TitleWindow();
        private Player player = new Player();
        private Combat combat = new Combat();
        private EnemyManager manager;
        private Enemy enemy;
        private int gameTime = 0;
        private bool mute = false;
        public GameWindow()
        {

            InitializeComponent();
            UpdateGame();
            Sound.field.Play();
            gameTimer.Interval = 1000;
            gameTimer.Tick += UpdateClock;
            gameTimer.Start();
        }

        private void UpdateClock(object sender, EventArgs e)
        {
            gameTime++;
            clockLBL.Text = gameTime.ToString();
        }

        public void UpdateGame()
        {
            combat.UpdateClass(this, ref player);
            player.UpdateGame(this, combat);

            //{ maxHP, currentHP, combatPWR, damageDEF, gainedEXP, exptoLVL};
            int[] stats = player.GetPlayerStats();

            mHpLBL.Text = stats[0].ToString();
            chpLBL.Text = stats[1].ToString();
            pwrLBL.Text = stats[2].ToString();
            defLBL.Text = stats[3].ToString();
            expLBL.Text = stats[4].ToString();
            lvlLBL.Text = stats[5].ToString();

            monNameLBL.Text = enemy.GetName().ToString();
            monHpLBL.Text = enemy.GetHealth().ToString();
        }

        public void SetEnemy(Enemy monster)
        {
            enemy = monster;
        }

        public void SetManager(EnemyManager mgr)
        {
            manager = mgr;
        }

        public void SetCombat(Combat cmbt)
        {
            combat = cmbt;
        }

        private void Weapon_Click(object sender, EventArgs e)
        {
            UpdateCombatTXT("You attack!");
            combat.CommenceCombat("FIGHT");
        }

        private void Tool_Click(object sender, EventArgs e)
        {
            UpdateCombatTXT("You shoot your crossbow!");
            combat.CommenceCombat("TOOLS");
        }

        private void Magic_Click(object sender, EventArgs e)
        {
            UpdateCombatTXT("You cast a spell on the creature!");
            combat.CommenceCombat("MAGIC");
        }

        private void Heal_Click(object sender, EventArgs e)
        {
            UpdateCombatTXT("You defend and heal!");
            combat.CommenceCombat("HEAL");
        }

        private void Flee_Click(object sender, EventArgs e)
        {
            UpdateCombatTXT("You try to run...");
            combat.CommenceCombat("FLEE");
        }

        private void Rest_Click(object sender, EventArgs e)
        {
            player.UpdateMoves();
            player.UpdateHealth(player.GetMaxHealth());
            UpdateGame();
        }

        public void SetCombatPanel(bool set)
        {
            combatPNL.Visible = set;
        }

        private void Adventure_Click(object sender, EventArgs e)
        {
            player.UpdateMoves();
            player.UpdateProgress();
            UpdateBackground();
            UpdateGame();
            int progress = player.GetProgress();

            storyTXT.Text = story.Progression(player.GetProgress());
            if (progress == 21 || progress == 41)
            {
                manager.GetBoss();
            }
            else if (progress < 39)
            {
                manager.GetRandomEncounter();
            }
            UpdateGame();

        }

        private void UpdateBackground()
        {
            int progress = player.GetProgress();

            if (progress == 2)
            {
                this.BackgroundImage = Properties.Resources.Ruins1;
            }
            else if (progress == 5)
            {
                this.BackgroundImage = Properties.Resources.Grassland;
            }
            else if (progress == 7)
            {
                this.BackgroundImage = Properties.Resources.Meadow;
            }
            else if (progress == 11)
            {
                if (!mute)
                {
                    Sound.dungeon.Play();
                }

                this.BackgroundImage = Properties.Resources.PoisonSwamp;
            }
            else if (progress == 21)
            {
                this.BackgroundImage = Properties.Resources.Translucent;
            }
            else if (progress == 22)
            {
                this.BackgroundImage = Properties.Resources.DemonCastle;
            }
            else if (progress == 39)
            {
                this.BackgroundImage = Properties.Resources.DarkSpace;
            }
        }

        public void ResumeStory()
        {
            if (!mute)
            {
                if (player.GetProgress() < 11)
                {
                    Sound.field.Play();
                }
                else
                {
                    Sound.dungeon.Play();
                }
            }
            storyTXT.Visible = true;
            advPNL.Visible = true;
            combatTXT.Visible = false;
            combatPNL.Visible = false;
            monPNL.Visible = false;
            GetMonsterIMG(-1);
            UpdateGame();
        }

        public void MonsterEncounter()
        {
            UpdateGame();
            GetMonsterIMG(manager.GetIndex());
            if (!mute)
            {
                Sound.battle.PlayLooping();
            }
            storyTXT.Visible = false;
            advPNL.Visible = false;
            combatTXT.Visible = true;
            combatPNL.Visible = true;
            monPNL.Visible = true;
            combatTXT.Text = "";
            UpdateCombatTXT("You have encountered a " + enemy.GetName() + ".");
            UpdateGame();
        }

        public void GetMonsterIMG(int i)
        {
            switch (i)
            {
                case 0:
                    monsterIMG.Image = Properties.Resources.Rat;
                    break;
                case 1:
                    monsterIMG.Image = Properties.Resources.Bat;
                    break;
                case 2:
                    monsterIMG.Image = Properties.Resources.Slime;
                    break;
                case 3:
                    monsterIMG.Image = Properties.Resources.Hornet;
                    break;
                case 4:
                    monsterIMG.Image = Properties.Resources.Spider;
                    break;
                case 5:
                    monsterIMG.Image = Properties.Resources.Snake;
                    break;
                case 6:
                    monsterIMG.Image = Properties.Resources.Ogre;
                    break;
                case 7:
                    monsterIMG.Image = Properties.Resources.Soldier;
                    break;
                case 8:
                    monsterIMG.Image = Properties.Resources.Imp;
                    break;
                case 9:
                    monsterIMG.Image = Properties.Resources.Zombie;
                    break;
                case 10:
                    monsterIMG.Image = Properties.Resources.Assassin;
                    break;
                case 11:
                    monsterIMG.Image = Properties.Resources.Chimera;
                    break;
                case 12:
                    monsterIMG.Image = Properties.Resources.Wizard_m;
                    break;
                case 13:
                    monsterIMG.Image = Properties.Resources.Dragon;
                    break;
                case 14:
                    monsterIMG.Image = Properties.Resources.Fanatic;
                    break;
                case 15:
                    monsterIMG.Image = Properties.Resources.Gayzer;
                    break;
                case 16:
                    monsterIMG.Image = Properties.Resources.Firespirit;
                    break;
                case 17:
                    monsterIMG.Image = Properties.Resources.Vampire;
                    break;
                case 18:
                    monsterIMG.Image = Properties.Resources.Evilking;
                    break;
                case 19:
                    monsterIMG.Image = Properties.Resources.Demon;
                    break;
                case 20:
                    monsterIMG.Image = Properties.Resources.Evilgod;
                    break;


                default:
                    monsterIMG.Image = null;
                    break;

            }

        }


        public void UpdateCombatTXT(string text)
        {
            combatTXT.AppendText(text += "\r\n");
        }

        public void ShowMessage(string msg)
        {
            MessageBox.Show(msg);
        }

        public void GameOver(string game)
        {
            //{battles, takenDMG, dealtDMG, moves};
            int[] gamestats = player.GetGameStats();

            if (game == "WIN")
            {
                Sound.end.Play();
                ShowMessage("Jim has saved the world. Thanks for playing! You did: \n" + gamestats[3]
                    + " moves\n" + gamestats[2] + " Damage Dealt\n" + gamestats[1] + " Damage Taken\n"
                    + gamestats[0] + " Total Battles");
                Application.Exit();
            }
            if (game == "LOSE")
            {
                ShowMessage("He's dead Jim >_< Game Over!");
                Application.Exit();
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }

        private void Restart_Click(object sender, EventArgs e)
        {
            title.Show();
            Hide();
        }

        private void muteBTN_Click(object sender, EventArgs e)
        {
            if (mute)
            {
                mute = false;
            }
            else
            {
                mute = true;
            }

            if (!mute)
            {
                if (monPNL.Visible)
                {
                    Sound.battle.PlayLooping();
                }
                else if (player.GetProgress() < 11)
                {
                    Sound.field.Play();
                }
                else
                {
                    Sound.dungeon.Play();
                }
            }
            else
            {
                Sound.battle.Stop();
                Sound.field.Stop();
                Sound.dungeon.Stop();
                Sound.end.Stop();
                Sound.title.Stop();
            }

            UpdateGame();
        }
    }
}
