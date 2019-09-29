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
        
        GameEngine gameEngine;

        public frmBattleSim()
        {
            InitializeComponent();
        }

        private void frmBattleSim_Load(object sender, EventArgs e)
        {

            gameEngine = new GameEngine(5);
            lblMap.Text = gameEngine.Map.convertMap();

            rtxUnitInfo.Text = gameEngine.getStats(gameEngine.Map.Units);


        }

        

        private void btnStart_Click(object sender, EventArgs e)
        {
            tmrOnly.Enabled = true;
            tmrOnly.Start();
            
        }

        private void playGame(object sender, EventArgs e)
        {
            gameEngine.gameLogic(gameEngine.Map.Units);
            lblMap.Text = gameEngine.Map.convertMap();
            lblTimer.Text = Convert.ToString(Convert.ToInt32(lblTimer.Text) + 1);
            rtxUnitInfo.Text = gameEngine.getStats(gameEngine.Map.Units);

        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            tmrOnly.Stop();
        }
    }
}
