using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReeceNewman_19011948_GADE1B_POE
{
    class GameEngine
    {
        private Map map;
        int counter = 0;
        public Map Map { get => map; }


        public GameEngine(int numberOfUnits)
        {

            map = new Map(numberOfUnits, 20, 20);
            map.newBattlefield();

        }

        public void gameLogic(Unit[] unit)
        {

            bool resetCounter = false;

            for (int i = 0; i < unit.Length; i++)
            {
                unit[i].death(); //Check for death and set relevant variable
                unit[i].IsAttacking = false;

                if (unit[i].IsDead == false) //If unit is not dead
                {
                    Unit closest = unit[i].closestUnit(unit); //Determines the closest unit to this unit and stores that unit in 'closest'

                    if (unit[i].attackingRange(closest) == false || unit[i].Health / unit[i].MaxHealth * 100 < 25) //If the unit is below 25% hp or is not in range of the closest enemy 
                    {
                        unit[i].movement(closest, map.MapSizeX, map.MapSizeY); //Move

                        map.populateMap(); //Refresh Map
                    }
                    else if (unit[i].Faction != closest.Faction) //If the unit is not part of the same team
                    {
                        unit[i].combat(closest); //Do combat
                        map.populateMap(); //Refreh map
                    }

                }


            }


            if (resetCounter == true)
            {
                resetCounter = false;
                counter = 0;
            }
            else
            {
                ++counter;

            }

        }

        public string getStats(Unit[] unit)
        {
            string stats = "";
            for (int i = 0; i < unit.Length; i++)
            {
                stats += unit[i].ToString();
            }
 
            return stats;
        }
    }
}
