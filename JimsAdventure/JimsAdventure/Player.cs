using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RPG
{
    public class Player
    {
        private GameWindow main;
        private Combat combat;
        private Random random = new Random();
        public void UpdateGame(GameWindow gm, Combat c)
        {
            main = gm;
            combat = c;
        }

        // member variables
        private int maxHP, currentHP, combatPWR, damageDEF, gainedEXP,
            moves, story, bracketEXP, currentLVL, exptoLVL;

        //Game Stats
        private int battles, takenDMG, dealtDMG;
        private float critLUCK, toHIT;

        // constructor
        public Player()
        {
            //playerstats
            maxHP = 80;
            currentHP = 80;
            combatPWR = 10;
            damageDEF = 7;
            gainedEXP = 0;
            moves = 0;
            story = 0;
            bracketEXP = 30;
            currentLVL = 1;
            exptoLVL = 30;
            critLUCK = .05f;
            toHIT = .95f;

            //gamestats
            battles = 0;
            takenDMG = 0;
            dealtDMG = 0;

        }
        public void LevelUp()
        {
            currentLVL++;
            int hp = Convert.ToInt32(currentLVL * 8.4f);
            maxHP += hp;
            int power = Convert.ToInt32(currentLVL * 1.85f);
            combatPWR += power;
            int defense = Convert.ToInt32(currentLVL * 1.25f);
            damageDEF += defense;
            int experience = Convert.ToInt32(bracketEXP * 1.33f);
            bracketEXP += experience;
            exptoLVL = bracketEXP - gainedEXP;
            UpdateHealth(maxHP);
            main.ShowMessage("YOU LEVELED UP! HP +" + hp + " AP +" + power + " DEF +" + defense);
        }

        // accessors
    
        public int[] GetGameStats()
        {
            int[] stats = new int[4] { battles, takenDMG, dealtDMG, moves };
            return stats;
        }

        public int[] GetPlayerStats()
        {
            int[] stats = new int[6] { maxHP, currentHP, combatPWR, damageDEF, exptoLVL, currentLVL };
            return stats;
        }

        public int GetProgress()
        {
            return story;
        }

        public float GetHitChance()
        {
            return toHIT;
        }
        public int GetHealth()
        {
            return currentHP;
        }
        public int GetMaxHealth()
        {
            return maxHP;
        }

        public int GetPWR()
        {
            return combatPWR;
        }

        public int GetLevel()
        {
            return currentLVL;
        }

        public float GetLuck()
        {
            return critLUCK;
        }

        public float GetToHIT()
        {
            return toHIT;
        }

        public void UpdateProgress()
        {
            story++;
        }

        public void UpdateBattles()
        {
            battles++;
        }

        public void UpdateMoves()
        {
            moves++;
        }

        public void UpdateDealtDMG(int dmg)
        {
            dealtDMG += dmg;
        }

        public void UpdateTakenDMG(int dmg)
        {
            takenDMG += dmg;
        }

        public void UpdateHealth(int hp)
        {
            currentHP += hp;
            if (currentHP < 1)
            {
                main.GameOver("LOSE");
            }
            else if (currentHP > maxHP)
            {
                currentHP = maxHP;
            }
            main.UpdateGame();
        }

        public int SetDamageTaken(int dmg, MONSTERTYPE type, bool crit)
        {
            
            int damage = dmg - random.Next(6);
            if (type == MONSTERTYPE.NORMAL)
            {
                damage -= damageDEF;
            }
            else if (type == MONSTERTYPE.FLYER)
            {
                damage -= damageDEF / 2;
            }
            if (crit)
            {
                damage = damage * 2;
            }
            if (damage < 0)
            {
                damage = 0;
            }
            UpdateHealth(damage * -1);
            return damage;
        }

        public void UpdateEXP(int exp)
        {
            gainedEXP += exp;
            exptoLVL = bracketEXP - gainedEXP;
            if (exptoLVL <= 0)
            {
                LevelUp();
            }
        }
    }
}
