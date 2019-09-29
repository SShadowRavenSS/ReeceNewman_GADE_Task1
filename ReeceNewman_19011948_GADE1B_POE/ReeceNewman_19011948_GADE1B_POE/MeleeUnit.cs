using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReeceNewman_19011948_GADE1B_POE
{
    class MeleeUnit : Unit
    {
        //Constructor Initializer for Melee Units that passes the passed in parameters to the base class' constructor
        public MeleeUnit(int xPos, int yPos, int health, int speed, int range, char symbol, int attack, int faction) : base(xPos, yPos, health, faction, speed, attack, range, symbol, health)
        {

        }

    }
}
