using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReeceNewman_19011948_GADE1B_POE
{
    class GameEngine
    {
        private int roundCounter;
        private Map map;

        public int RoundCounter { get => roundCounter; }
        public Map Map { get => map; }
        

        public GameEngine(int numberOfUnits)
        {
            map = new Map(numberOfUnits, 20, 20);
            map.newBattlefield();
            
        } 

        public string gameLogic(Unit[] unit)
        {
            string stats = "";

            for (int i = 0; i < unit.Length; i++)
            {
                string unitType = unit[i].GetType().ToString();
                
                string[] unitArr = unitType.Split('.');
                unitType = unitArr[unitArr.Length - 1];
                string directionMoved = "";

                if (unitType == "MeleeUnit")
                {
                    MeleeUnit u = (MeleeUnit)unit[i]; //explicit cast a temp unit of type Melee to use 

                    if (u.death() == false)
                    {
                        Unit closest = u.closestUnit(unit); //Determines the closest unit to u

                        string typeUnit = closest.GetType().ToString();
                        string[] arrUnit = typeUnit.Split('.');
                        typeUnit = arrUnit[unitArr.Length - 1];

                        if (typeUnit == "MeleeUnit")
                        {
                            MeleeUnit mU = (MeleeUnit)closest; //explicit cast a temp Melee unit of the closest unit 

                            if (mU.death() == false)
                            {

                                if (u.attackingRange(mU) == false && u.IsAttacking == false || u.Health / u.MaxHealth * 100 < 25)
                                {
                                    directionMoved = u.movement(mU);
                                    //map.positionChange(directionMoved, u);
                                    map.populateMap();
                                }
                                else if(u.Faction != mU.Faction)
                                {
                                    u.combat(mU);
                                    map.populateMap();
                                }
                            }
                            else
                            {
                                u.IsAttacking = false;
                            }

                        }
                        else
                        {
                            RangedUnit rU = (RangedUnit)closest;
                            if (rU.death() == false)
                            {

                                if (u.attackingRange(rU) == false && u.IsAttacking == false || u.Health / u.MaxHealth * 100 < 25)
                                {
                                    directionMoved = u.movement(rU);
                                    //map.positionChange(directionMoved, u);
                                    map.populateMap();
                                }
                                else if (u.Faction != rU.Faction)
                                {
                                    u.combat(rU);
                                    map.populateMap();
                                }
                            }
                            else
                            {
                                u.IsAttacking = false;
                            }
                        }
                        
                    }
                }
                else
                {
                    RangedUnit r = (RangedUnit)unit[i];

                    if (r.death() == false)
                    {



                        Unit closest = r.closestUnit(unit);

                        string typeUnit = closest.GetType().ToString();
                        string[] arrUnit = typeUnit.Split('.');
                        typeUnit = arrUnit[unitArr.Length - 1];

                        if (typeUnit == "MeleeUnit")
                        {
                            MeleeUnit mU = (MeleeUnit)closest;

                            if(mU.death() == false)
                            {
                                if (r.attackingRange(mU) == false && r.IsAttacking == false || r.Health / r.MaxHealth * 100 < 25)
                                {
                                    directionMoved = r.movement(mU);
                                    //map.positionChange(directionMoved, r);
                                    map.populateMap();
                                }
                                else if (r.Faction != mU.Faction)
                                {
                                    r.combat(mU);
                                    map.populateMap();
                                }

                            }
                            else
                            {
                                r.IsAttacking = false; 
                            }


                        }
                        else
                        {
                            RangedUnit rU = (RangedUnit)closest;
                            
                            if(rU.death() == false)
                            {
                                if (r.attackingRange(rU) == false && r.IsAttacking == false || r.Health / r.MaxHealth * 100 < 25)
                                {
                                    directionMoved = r.movement(rU);
                                    //map.positionChange(directionMoved, r);
                                    map.populateMap();
                                }
                                else if (r.Faction != rU.Faction)
                                {
                                    r.combat(rU);
                                    map.populateMap();
                                }
                            }
                            else
                            {
                                r.IsAttacking = false;
                            }

                                
                            
                        }
                        
                    }
                }
                
            }


            for (int k = 0; k < unit.Length; k++)
            {
                string unitType = unit[k].GetType().ToString();

                string[] unitArr = unitType.Split('.');
                unitType = unitArr[unitArr.Length - 1];

                if(unitType == "MeleeUnit")
                {
                    MeleeUnit u = (MeleeUnit)unit[k];
                    stats += u.ToString();
                }
                else
                {
                    RangedUnit r = (RangedUnit)unit[k];
                    stats += r.ToString();
                }
            }
            

            this.roundCounter++;
            return stats;
        }
    }
}
