using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReeceNewman_19011948_GADE1B_POE
{
    class GameEngine
    {
        //Variable declarations
        private Map map;
        int counter = 0;
        public Map Map { get => map; }

        //Constructor for gameEngine
        public GameEngine(int numberOfUnits)
        {
            //Creates map
            map = new Map(numberOfUnits, 20, 20);
            map.newBattlefield();

        }

        //Method that operates the games logic and controlls units
        public void gameLogic(Unit[] unit)
        {
            //Loop that runs through all the units in the unit array
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
                        map.populateMap(); //Refresh map
                    }

                }

            }

        }

        //Method that returns formatted string of all the units stats
        public string getStats(Unit[] unit)
        {
            string stats = "";

            //loop to run through all the units in the passed in array
            for (int i = 0; i < unit.Length; i++)
            {
                stats += unit[i].ToString();
            }
 
            return stats;
        }
    }
}
