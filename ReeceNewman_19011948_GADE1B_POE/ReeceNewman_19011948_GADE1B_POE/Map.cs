using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReeceNewman_19011948_GADE1B_POE
{
    class Map
    {
        private char[,] map;
        private int mapSizeX, mapSizeY;
        Random rng = new Random();
        private Unit[] units;
        

        public char[,] MapDisplay { get => map; set => map = value; }
        public int MapSizeX { get => mapSizeX; }
        public int MapSizeY { get => mapSizeY; }
        public Random Rng { get => rng; set => rng = value; }
        public Unit[] Units { get => units; set => units = value; }

        public Map(int numOfUnits, int mapSizeX, int mapsizeY)
        {
            this.mapSizeX = mapSizeX;
            this.mapSizeY = mapsizeY;
            MapDisplay = new char[MapSizeY, MapSizeX];
            Units = new Unit[numOfUnits];
            
        }

        

        public void newBattlefield()
        {
            int xPos, yPos, type, faction;
            

            for (int l = 0; l < Units.Length; l++)
            {
                xPos = Rng.Next(0, 20);
                yPos = Rng.Next(0, 20);
                type = Rng.Next(0, 2);
                faction = Rng.Next(0, 2);
                

                if (type == 0 && faction == 0)
                {
                    MeleeUnit unit = new MeleeUnit(xPos,yPos,120,1,1,'M',10,faction);
                    Units[l] = unit;
                }
                else if(type == 1 && faction == 0)
                {
                    RangedUnit unit = new RangedUnit(xPos,yPos,100,1,2,'R',5,faction);
                    Units[l] = unit;
                }
                else if(type == 0 && faction == 1)
                {
                    MeleeUnit unit = new MeleeUnit(xPos, yPos, 120, 1, 1, 'm', 10, faction);
                    Units[l] = unit;
                }
                else if(type == 1 && faction == 1)
                {
                    RangedUnit unit = new RangedUnit(xPos, yPos, 100, 1, 2, 'r', 5, faction);
                    Units[l] = unit;
                }
            }

            populateMap();
                       
        }

        public string convertMap()
        {
            string mapOutput = "";

            for (int i = 0; i < mapSizeY; i++)
            {
                for (int k = 0; k < mapSizeX; k++)
                {
                    mapOutput += Convert.ToString(MapDisplay[i, k]);
                }
                mapOutput += "\n";
            }

            return mapOutput;
        }

        public void populateMap()
        {
            
            for (int i = 0; i < MapSizeY; i++)
            { 

                for (int k = 0; k < MapSizeX; k++)
                {
                    MapDisplay[i, k] = '.';
                   
                }
                
            }

            for (int m = 0; m < Units.Length; m++)
            {
                
                insertUnits(Units[m]);
                
            }
            
        }

        private void insertUnits(Unit unit)
        {
            string unitType = unit.GetType().ToString();
            string[] unitArr = unitType.Split('.');
            unitType = unitArr[unitArr.Length - 1];


            if (unitType == "MeleeUnit")
            {
                MeleeUnit u = (MeleeUnit)unit;

                if(u.death() == false)
                {
                    MapDisplay[u.YPos, u.XPos] = u.Symbol;
                }
                

            }
            else if(unitType == "RangedUnit")
            {
                RangedUnit u = (RangedUnit)unit;

                if(u.death() == false)
                {
                    MapDisplay[u.YPos, u.XPos] = u.Symbol;
                }
                
            }
   
        }

        public void positionChange(string direction, Unit unit)
        {
            string unitType = unit.GetType().ToString();
            string[] unitArr = unitType.Split('.');
            unitType = unitArr[unitArr.Length - 1];

            if(unitType == "MeleeUnit")
            {
                MeleeUnit u = (MeleeUnit)unit;

                if (u.death() == false)
                {
                    
                    if (direction == "Up")
                    {
                        MapDisplay[u.XPos, u.YPos] = u.Symbol;
                        MapDisplay[u.XPos, u.YPos + 1] = '.';
                    }
                    else if (direction == "Down")
                    {
                        MapDisplay[u.XPos, u.YPos] = u.Symbol;
                        MapDisplay[u.XPos, u.YPos - 1] = '.';
                    }
                    else if (direction == "Left")
                    {
                        MapDisplay[u.XPos, u.YPos] = u.Symbol;
                        MapDisplay[u.XPos + 1, u.YPos] = '.';
                    }
                    else if (direction == "Right")
                    {
                        MapDisplay[u.XPos, u.YPos] = u.Symbol;
                        MapDisplay[u.XPos - 1, u.YPos] = '.';
                    }
                }
                else
                {
                    MapDisplay[u.XPos, u.YPos] = 'D';
                }

                

            }
            else
            {
                RangedUnit r = (RangedUnit)unit;
                
                if (r.death() == false)
                {
                    Console.WriteLine("lol1");
                    if (direction == "Up")
                    {
                        MapDisplay[r.XPos, r.YPos] = r.Symbol;
                        MapDisplay[r.XPos, r.YPos + 1] = '.';
                    }
                    else if (direction == "Down")
                    {
                        MapDisplay[r.XPos, r.YPos] = r.Symbol;
                        MapDisplay[r.XPos, r.YPos - 1] = '.';
                    }
                    else if (direction == "Left")
                    {
                        MapDisplay[r.XPos, r.YPos] = r.Symbol;
                        MapDisplay[r.XPos + 1, r.YPos] = '.';
                    }
                    else if (direction == "Right")
                    {
                        MapDisplay[r.XPos, r.YPos] = r.Symbol;
                        MapDisplay[r.XPos - 1, r.YPos] = '.';
                    }
                }
                else
                {
                    MapDisplay[r.XPos, r.YPos] = 'D';
                }
                
            }

        }
    }
}
