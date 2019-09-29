using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReeceNewman_19011948_GADE1B_POE
{
    public partial class frmBattleSim : Form
    {
        
        GameEngine gameEngine; //Creates space in memory for object of class GameEngine to run the game

        public frmBattleSim()
        {
            InitializeComponent();
        }

        private void frmBattleSim_Load(object sender, EventArgs e)
        {

            gameEngine = new GameEngine(5); //Initializes the gameEngine with its parameters (5 units)
            lblMap.Text = gameEngine.Map.convertMap(); //Updates map text and displays it on the form

            rtxUnitInfo.Text = gameEngine.getStats(gameEngine.Map.Units); //Updates the units stats and displays it on the form


        }

        

        private void btnStart_Click(object sender, EventArgs e) //Enables and starts the timer on the click of start button event
        {
            tmrOnly.Enabled = true; 
            tmrOnly.Start();
            
        }

        private void playGame(object sender, EventArgs e)
        {
            gameEngine.gameLogic(gameEngine.Map.Units); //Calls the gamelogic method of the gameEngine to update all the logic of the units
            lblMap.Text = gameEngine.Map.convertMap(); //Displays the updated map on the Label in the form
            lblTimer.Text = Convert.ToString(Convert.ToInt32(lblTimer.Text) + 1); //Updates the timer text
            rtxUnitInfo.Text = gameEngine.getStats(gameEngine.Map.Units); //Displays the updated unit info on the Label in the form

        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            tmrOnly.Stop(); //Stops the timer
        }
    }
}
