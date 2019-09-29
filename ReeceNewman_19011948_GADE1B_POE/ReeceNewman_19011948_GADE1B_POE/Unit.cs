using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReeceNewman_19011948_GADE1B_POE
{
    abstract class Unit
    {
        protected int faction;
        protected char symbol;
        protected bool isAttacking;
        protected int xPos;
        protected int yPos;
        protected int health;
        protected int maxHealth;
        protected int speed;
        protected int attack;
        protected int attackRange;

        

        abstract public string movement(Unit moveToUnit);
        abstract public void combat(Unit unitToAttack);
        abstract public bool attackingRange(Unit unit);
        abstract public Unit closestUnit(Unit[] units);
        abstract public bool death();
        public abstract override string ToString();


        public Unit(int xPos, int yPos, int health, int faction, int speed, int attack, int attackRange, char symbol)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.health = health;
            this.maxHealth = health;
            this.faction = faction;
            this.speed = speed;
            this.attack = attack;
            this.attackRange = attackRange;
            this.symbol = symbol;      
        }
    }
}
