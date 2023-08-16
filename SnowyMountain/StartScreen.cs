using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnowyMountain
{
    public partial class StartScreen : Form
    {
        public StartScreen()
        {
            InitializeComponent();
        }


        private void LoadGame(object sender, EventArgs e)
        {
            var gameWindow = new Level1();
            this.Hide();
            gameWindow.Show();
        }
    }
}
