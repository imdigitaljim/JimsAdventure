using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RPG
{
    public enum DAMAGETYPE { NORMAL, MAGIC, TOOL };

    public class Combat
    {
        private Random random = new Random();
        private EnemyManager manager = new EnemyManager();
        private Player player;
        private GameWindow main;
        private Timer timer;
        private Enemy enemy;
        private string delayType;
        private bool activeCombat = false;

        public bool GetActiveCombat()
        {
            return activeCombat;
        }

        public void UpdateClass(GameWindow gm, ref Player p)
        {
            main = gm;
            player = p;
            UpdateGame();
        }

        public void UpdateGame()
        {
            //passing updates to it's own objects
            manager.UpdateClass(main, this, player);

            //returning updates
            main.SetManager(manager);
            main.SetEnemy(enemy);
        }

        public void SetInCombat(bool active)
        {
            activeCombat = active;
        }

        public void SetEnemy(Enemy e)
        {
            enemy = e;
        }

        private bool HitSuccess(float hit)
        {
            if (random.Next(100) <= hit * 100)
            {
                return true;
            }
            StartDialogDelay();
            main.UpdateCombatTXT("It missed!");
            return false;
        }

        private bool CritSuccess(float luck)
        {
            if (random.Next(100) <= luck * 100)
            {
                StartDialogDelay();
                main.UpdateCombatTXT("It's a critical hit!!!");
                return true;
            }
            return false;
        }

        private void PlayerDamage(DAMAGETYPE dmgtype)
        {
            int damageDLT;
            damageDLT = enemy.SetDamageTaken(player.GetPWR(), dmgtype, CritSuccess(player.GetLuck()));
            player.UpdateTakenDMG(damageDLT);
            if (damageDLT < 1)
            {
                StartDialogDelay();
                main.UpdateCombatTXT("Your attack was ineffective!!");
                return;
            }
            StartDialogDelay();
            main.UpdateCombatTXT("You hit " + enemy.GetName() + " for " + damageDLT + " !");
        }


        private void StartDialogDelay()
        {

            timer = new Timer();
            timer.Interval = 1500;
            timer.Tick += EndDialogDelay;
            timer.Start();
        }
        private void EndDialogDelay(object sender, EventArgs e)
        {
            Timer timer = (Timer)sender;
            timer.Stop();
            main.SetCombat(this);
            main.UpdateGame();
            if (delayType == "MONSTERDAMAGE")
            {
                MonsterDamage();
                main.SetCombatPanel(true);
            }
            else if (delayType == "MONSTERMISS")
            {
                main.SetCombatPanel(true);
            }
            delayType = "";
        }

        private void MonsterDamage()
        {
            int damageDLT;
            damageDLT = player.SetDamageTaken(enemy.GetMonsterDMG(), enemy.GetMonsterType(), CritSuccess(.03f));
            player.UpdateDealtDMG(damageDLT);
            if (damageDLT < 1)
            {
                StartDialogDelay();
                main.UpdateCombatTXT("The attack was ineffective!!");
            }
            else
            {
                main.UpdateCombatTXT("The " + enemy.GetName() + " hit you for " + damageDLT + " !");
                if (enemy.GetHealth() < 1)
                {
                    main.SetCombatPanel(false);
                }
            }
        }

        public void CommenceCombat(string selection)
        {
            main.SetCombatPanel(false);
            player.UpdateMoves();
            activeCombat = true;
            if (selection == "FIGHT" && HitSuccess(player.GetToHIT()))
            {
                PlayerDamage(DAMAGETYPE.NORMAL);
            }
            else if (selection == "TOOLS" && HitSuccess(player.GetToHIT()))
            {
                PlayerDamage(DAMAGETYPE.TOOL);
            }
            else if (selection == "MAGIC")
            {
                PlayerDamage(DAMAGETYPE.MAGIC);
            }
            else if (selection == "HEAL")
            {
                int healbefore = player.GetHealth();
                player.UpdateHealth(player.GetLevel() * 4 * (random.Next(5) + 1));
                main.UpdateCombatTXT("You heal for " + (player.GetHealth() - healbefore) + " !");
            }
            else if (selection == "FLEE")
            {
                if (enemy.GetPowerLVL() == MONSTERTIER.NORMAL)
                {

                    if (random.Next(100) > 20)
                    {
                        player.UpdateBattles();
                        main.UpdateGame();
                        main.ResumeStory();
                        main.UpdateCombatTXT("You have escaped the battle!");
                        return;
                    }
                }
                else
                {
                    main.UpdateCombatTXT("You could not flee!");
                }
            }

            if (activeCombat) // Check if still in combat
            {
                main.UpdateCombatTXT("The " + enemy.GetName() + " attacks!");
                if (HitSuccess(.90f))
                {
                    delayType = "MONSTERDAMAGE";
                }
                else
                {
                    delayType = "MONSTERMISS";
                }
                StartDialogDelay();

            }
        }

        public void EndCombat()
        {
            activeCombat = false;
            player.UpdateBattles();
            main.ShowMessage("You killed the " + enemy.GetName() + " and gained " + enemy.GetAwardEXP() + " EXP");
            player.UpdateEXP(enemy.GetAwardEXP());
            if (enemy.GetPowerLVL() == MONSTERTIER.FINALBOSS)
            {
                main.GameOver("WIN");
                return;
            }
            main.ResumeStory();
        }
    }
}
