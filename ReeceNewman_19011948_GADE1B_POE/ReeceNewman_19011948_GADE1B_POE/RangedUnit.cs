﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReeceNewman_19011948_GADE1B_POE
{
    class RangedUnit : Unit
    {



        public RangedUnit(int xPos, int yPos, int health, int speed, int range, char symbol, int attack, int faction) : base(xPos, yPos, health, faction, speed, attack, range, symbol, health)
        {

        }

    }
}
