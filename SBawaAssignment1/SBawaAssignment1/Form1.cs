using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SBawaAssignment1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Design_Form design_form = new Design_Form();        //OPENING A NEW FOR FOR DESIGNING THE GAME;
            design_form.MdiParent = this.ParentForm;
            design_form.Show();
        }
    }
}
