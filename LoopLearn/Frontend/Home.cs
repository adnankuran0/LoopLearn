using LoopLearn.Backend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LoopLearn.Backend.Database;
using LoopLearn.Backend.Auth;
namespace LoopLearn.Frontend
{
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
            Tag = "Home";
            label1.Text += UserSession.Instance.UserName + "!";
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
