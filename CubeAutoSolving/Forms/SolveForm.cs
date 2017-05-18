using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace RubiksAutoSolve
{
	public partial class SolveForm : Form
	{
       

        /// <summary>
        ///     New form constructor
        /// </summary>
        public SolveForm()
		{
			InitializeComponent();
		}
        
        private void solveButton_Click(object sender, EventArgs e)
        {
            LayerByLayer lbl = new LayerByLayer();
            lbl.SolveCube();
        }

        
    }
}
