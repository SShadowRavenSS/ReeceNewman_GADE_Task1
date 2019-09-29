using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReeceNewman_19011948_GADE1B_POE
{
    class Map
    {
        //Create variables
        private char[,] map;
        private int mapSizeX, mapSizeY;
        Random rng = new Random();
        private Unit[] units;
        
        //Create accessors for the variables
        public char[,] MapDisplay { get => map; set => map = value; }
        public int MapSizeX { get => mapSizeX; }
        public int MapSizeY { get => mapSizeY; }
        public Random Rng { get => rng; set => rng = value; }
        public Unit[] Units { get => units; set => units = value; }

        //Constructor for the class
        public Map(int numOfUnits, int mapSizeX, int mapsizeY) //takes in parameters
        {
            //initializes parameters
            this.mapSizeX = mapSizeX; 
            this.mapSizeY = mapsizeY;
            MapDisplay = new char[MapSizeY, MapSizeX];
            Units = new Unit[numOfUnits];
            
        }


        //Generates a new Battlefield from scratch
        public void newBattlefield() 
        {
            //declare temp variables
            int xPos, yPos, type, faction;
            
            //Loop to create the units and storer them in the array
            for (int l = 0; l < Units.Length; l++)
            {
                //Random new values
                xPos = Rng.Next(0, 20);
                yPos = Rng.Next(0, 20);
                type = Rng.Next(0, 2);
                faction = Rng.Next(0, 2);
                
                //Create units based on the type and faction with the randomed values
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

            //Calss the method that populates the mapdisplay 
            populateMap();
                       
        }

        //Method that formats the map and returns the formatted string
        public string convertMap()
        {
            string mapOutput = "";

            //loop to add all the values of the map array to a string
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

        //Method that refreshes the map
        public void populateMap()
        {
            //loop to fill the array with 'grass' characters
            for (int i = 0; i < MapSizeY; i++)
            { 

                for (int k = 0; k < MapSizeX; k++)
                {

                    MapDisplay[i, k] = '.';
                   
                }
                
            }

            //loop that inserts the units into the array
            for (int m = 0; m < Units.Length; m++)
            {
                
                insertUnits(Units[m]);
                
            }
            
        }

        //Method that inserts the units into their coordinates on the map
        private void insertUnits(Unit unit)
        {
            //Type check for the passed in unit
            string unitType = unit.GetType().ToString();
            string[] unitArr = unitType.Split('.');
            unitType = unitArr[unitArr.Length - 1];

            if (unitType == "MeleeUnit")
            {
                //temp instance of the unit for use
                MeleeUnit u = (MeleeUnit)unit;

                if(u.IsDead == false)
                {
                    //adds the unit's symbol to the array in the correct position
                    MapDisplay[u.YPos, u.XPos] = u.Symbol; 
                }
                
            }
            else if(unitType == "RangedUnit")
            {
                //temp instance of the unit for use
                RangedUnit r = (RangedUnit)unit;

                if(r.IsDead == false)
                {
                    //adds the unit's symbol to the array in the correct position
                    MapDisplay[r.YPos, r.XPos] = r.Symbol;
                }
                
            }
   
        }
 
    }

}
