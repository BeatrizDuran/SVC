using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SVC
{
    public partial class frmNuevoAdmin : Form
    {
        public frmNuevoAdmin()
        {
            InitializeComponent();
          
        }
    private void button9_Click(object sender, EventArgs e)
        {
            new frmNuevoLogin().ShowDialog();
        }

        private void NuevoAdmin_Load(object sender, EventArgs e)
        {
            
        }
    }
}
