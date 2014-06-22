using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RPG
{
    public enum MONSTERTYPE { NORMAL, FLYER, MAGICAL };
    public enum MONSTERTIER { NORMAL, BOSS, FINALBOSS };

    public class Enemy
    {
        Random random = new Random();
        GameWindow main;
        Combat combat;

        protected int currentLVL, currentHP, combatPWR, damageDEF, awardEXP, dealtDMG, takenDMG;
        protected string name;
        protected MONSTERTIER mtier;
        protected MONSTERTYPE mtype;
        public void UpdateClass(GameWindow gm, Combat c)
        {
            main = gm;
            combat = c;
        }
        // constructors
        public Enemy()
        {
            currentLVL = 1;
            name = "";
            currentHP = 0;
            combatPWR = 0;
            damageDEF = 0;
            awardEXP = 0;
            mtype = MONSTERTYPE.NORMAL;
            mtier = MONSTERTIER.NORMAL;
        }

        public Enemy(int l, string n, int x, int y, int z, int e, MONSTERTYPE t, MONSTERTIER b)
        {
            currentLVL = l;
            name = n;
            currentHP = x;
            combatPWR = y;
            damageDEF = z;
            awardEXP = e;
            mtype = t;
            mtier = b;
        }

        public Enemy(int l, string n, int x, int y, int z, int e)
            : this(l, n, x, y, z, e, MONSTERTYPE.NORMAL, MONSTERTIER.NORMAL)
        {
        }

        public Enemy(int l, string n, int x, int y, int z, int e, MONSTERTIER p)
            : this(l, n, x, y, z, e, MONSTERTYPE.NORMAL, p)
        {
        }

        public Enemy(int l, string n, int x, int y, int z, int e, MONSTERTYPE t)
            : this(l, n, x, y, z, e, t, MONSTERTIER.NORMAL)
        {
        }

        // accessors
        public int SetDamageTaken(int dmg, DAMAGETYPE dmgtype, bool crit)
        {
            int damage = dmg - random.Next(5);
            damage -= damageDEF;

            if (dmgtype == DAMAGETYPE.NORMAL && mtype == MONSTERTYPE.MAGICAL)
            {
                damage = Convert.ToInt32(damage * 1.25f);
            }
            else if (dmgtype == DAMAGETYPE.TOOL && mtype == MONSTERTYPE.FLYER)
            {
                damage = Convert.ToInt32(damage * 2.5f);
            }
            else if (dmgtype == DAMAGETYPE.NORMAL && mtype == MONSTERTYPE.FLYER)
            {
                damage = Convert.ToInt32(damage * .75f);
            }
            else if (dmgtype == DAMAGETYPE.MAGIC && mtype == MONSTERTYPE.MAGICAL)
            {
                damage = Convert.ToInt32(damage * .75f);
            }
            else if (dmgtype == DAMAGETYPE.MAGIC && mtype == MONSTERTYPE.NORMAL)
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
        public int GetHealth()
        {
            return currentHP;
        }


        public void UpdateHealth(int hp)
        {
            currentHP += hp;
            if (currentHP < 1)
            {
                combat.EndCombat();
                combat.SetEnemy(this);
                main.SetCombatPanel(false);
            }
            main.UpdateGame();
        }


        public void UpdateGame(GameWindow gm)
        {
            main = gm;
        }

        public void UpdateCombat(Combat c)
        {
            combat = c;
        }

        public string GetName()
        {
            return name;
        }

        public int GetAwardEXP()
        {
            return awardEXP;
        }

        public int GetMonsterDMG()
        {
            return combatPWR;
        }
        
        public MONSTERTYPE GetMonsterType()
        {
            return mtype;
        }
        
        public MONSTERTIER GetPowerLVL()
        {
            return mtier;
        }
    }
}
