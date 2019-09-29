using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReeceNewman_19011948_GADE1B_POE
{
    class RangedUnit : Unit
    {
        public int XPos { get => base.xPos; set => base.xPos = value; }
        public int YPos { get => base.yPos; set => base.yPos = value; }
        public int Health { get => base.health; set => base.health = value; }
        public int MaxHealth { get => base.maxHealth; }
        public int Speed { get => base.speed; set => base.speed = value; }
        public int Attack { get => base.attack; set => base.attack = value; }
        public int AttackRange { get => base.attackRange; set => base.attackRange = value; }
        public int Faction { get => base.faction; set => base.faction = value; }
        public char Symbol { get => base.symbol; set => base.symbol = value; }
        public bool IsAttacking { get => base.isAttacking; set => base.isAttacking = value; }
        
        private Random rng = new Random();

        public RangedUnit(int xPos, int yPos, int health, int speed, int range, char symbol, int attack, int faction) : base(xPos, yPos, health, faction, speed, attack, range, symbol)
        {

        }

        public override bool attackingRange(Unit unit)
        {
            string unitType = unit.GetType().ToString();
            string[] unitArr = unitType.Split('.');
            unitType = unitArr[unitArr.Length - 1];
            bool isInRange = false;

            if (unitType == "MeleeUnit")
            {
                MeleeUnit u = (MeleeUnit)unit;

                if (Math.Abs(u.XPos - this.XPos) > this.AttackRange && Math.Abs(u.YPos - this.YPos) > this.AttackRange)
                {
                    isInRange = false;
                }
                else
                {
                    isInRange = true;
                }
            }
            else if (unitType == "RangedUnit")
            {
                RangedUnit r = (RangedUnit)unit;

                if (Math.Abs(r.XPos - this.XPos) > this.AttackRange && Math.Abs(r.YPos - this.YPos) > this.AttackRange)
                {
                    isInRange = false;
                }
                else
                {
                    isInRange = true;
                }
            }

            
            return isInRange;
        }

        public override Unit closestUnit(Unit[] units)
        {
            int lowestDist = int.MaxValue;
            int closestUnit = int.MaxValue;
            int thisUnit = 0;

            for (int k = 0; k < units.Length; k++)
            {
                string unitType = units[k].GetType().ToString();
                string[] unitArr = unitType.Split('.');
                unitType = unitArr[unitArr.Length - 1];

                if (unitType == "MeleeUnit")
                {
                    MeleeUnit u = (MeleeUnit)units[k];
                    
                    if (u.death() == false)
                    {
                        int dist = Math.Abs(u.XPos - this.XPos) + Math.Abs(u.YPos - this.YPos);

                        if(dist != 0)
                        {
                            if (dist < lowestDist && u.Faction != this.Faction)
                            {
                                lowestDist = dist;
                                closestUnit = k;
                            }
                        }
                        else
                        {
                            thisUnit = k;
                        }
                        
                    }


                }
                else if (unitType == "RangedUnit")
                {
                    RangedUnit r = (RangedUnit)units[k];

                    if (r.death() == false)
                    {
                        int dist = Math.Abs(r.XPos - this.XPos) + Math.Abs(r.YPos - this.YPos);

                        if(dist != 0)
                        {
                            if (dist < lowestDist && r.Faction != this.Faction)
                            {
                                lowestDist = dist;
                                closestUnit = k;
                            }
                        }
                        else
                        {
                            thisUnit = k;
                        }
                        

                    }

                }

            }
            if(closestUnit != int.MaxValue)
            {
                return units[closestUnit];
            }
            else
            {
                return units[thisUnit];
            }
            

        }

        public override void combat(Unit unitToAttack)
        {

            string unitType = unitToAttack.GetType().ToString();
            string[] unitArr = unitType.Split('.');
            unitType = unitArr[unitArr.Length - 1];

            if (unitType == "MeleeUnit")
            {
                MeleeUnit u = (MeleeUnit)unitToAttack;

                u.Health -= this.Attack;

            }
            else if (unitType == "RangedUnit")
            {
                RangedUnit u = (RangedUnit)unitToAttack;

                u.Health -= this.Attack;

            }

            this.IsAttacking = true;

        }

        public override bool death()
        {
            bool isDead;

            if (this.Health >= 0)
            {
                isDead = false;
            }
            else
            {
                isDead = true;
                
            }

            return isDead;
        }

        public override string movement(Unit moveToUnit)
        {
            string returnVal = "";

            if (this.Health / this.MaxHealth * 100 < 25)
            {
                int randomDirection = rng.Next(0, 4);
                switch (randomDirection)
                {
                    case 0:
                        {
                            this.YPos -= 1;
                            returnVal = "Up";
                            break;
                        }
                    case 1:
                        {
                            this.YPos += 1;
                            returnVal = "Down";
                            break;
                        }
                    case 2:
                        {
                            this.XPos -= 1;
                            returnVal = "Left";
                            break;
                        }
                    case 3:
                        {
                            this.XPos += 1;
                            returnVal = "Right";
                            break;
                        }

                }
            }
            else
            {

                string unitType = moveToUnit.GetType().ToString();
                string[] unitArr = unitType.Split('.');
                unitType = unitArr[unitArr.Length - 1];

                if (unitType == "MeleeUnit")
                {
                    MeleeUnit u = (MeleeUnit)moveToUnit;

                    if (Math.Abs(u.XPos - this.XPos) > Math.Abs(u.YPos - this.YPos))
                    {
                        if (u.XPos - this.XPos > 0)
                        {
                            this.XPos += 1;
                            returnVal = "Right";
                        }
                        else if (u.XPos - this.XPos < 0)
                        {
                            this.XPos -= 1;
                            returnVal = "Left";
                        }
                    }
                    else
                    {
                        if (u.YPos - this.YPos > 0)
                        {
                            this.YPos += 1;
                            returnVal = "Down";
                        }
                        else if (u.YPos - this.YPos < 0)
                        {
                            this.YPos -= 1;
                            returnVal = "Up";
                        }
                    }
                }
                else if (unitType == "RangedUnit")
                {
                    RangedUnit u = (RangedUnit)moveToUnit;

                    if (Math.Abs(u.XPos - this.XPos) > Math.Abs(u.YPos - this.YPos))
                    {
                        if (u.XPos - this.XPos > 0)
                        {
                            this.XPos += 1;
                            returnVal = "Right";
                        }
                        else if (u.XPos - this.XPos < 0)
                        {
                            this.XPos -= 1;
                            returnVal = "Left";
                        }
                    }
                    else
                    {
                        if (u.YPos - this.YPos > 0)
                        {
                            this.YPos += 1;
                            returnVal = "Down";
                        }
                        else if (u.YPos - this.YPos < 0)
                        {
                            this.YPos -= 1;
                            returnVal = "Up";
                        }
                    }
                }

            }
            this.IsAttacking = false;
            return returnVal;
        }

        public override string ToString()
        {
            string output = "\n" +"_______________________________________" + "\n" + "This unit is a Ranged Unit " + "\n" + "This unit's x Position is: " + this.XPos + "\n" + "This unit's y Position is: "  + this.YPos + "\n" + "This unit's Health is: " + this.Health + "\n" + "This unit's Speed is: " + this.Speed + "\n" + "This unit's Range is: " + this.AttackRange + "\n" + "This unit's Attack is: " + this.Attack + "\n" + "This unit's Team is: Team " + this.Faction;

            return output;
        }
    }
}
