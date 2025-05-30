using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoopLearn.Frontend
{
    public partial class PuzzlePage : UserControl
    {
        public PuzzlePage()
        {
            InitializeComponent();
            generatebox();
            Tag = "Puzzle";
        }

        //for generating boxes
        public void generatebox()
        {
            int width = 60;
            int height = 60;
            int spacing = 10;
            int rowWidth = (width * 5) + spacing * 4;
            int x = ((this.ClientSize.Width - rowWidth) / 2) - 140 ; int y = 190;
            for (int i = 0; i <= 4; i++)
            {
                for (int j = 0; j <= 4; j++)
                {
                    Label kutu = new Label();
                    kutu.Text = ""; kutu.Font = new Font("Arial", 24, FontStyle.Bold);
                    kutu.Size = new Size(width, height);
                    kutu.TextAlign = ContentAlignment.MiddleCenter;
                    kutu.BorderStyle = BorderStyle.FixedSingle;
                    kutu.Location = new Point(x + j * (width + spacing), y);
                    kutu.BackColor = Color.LightGray; this.Controls.Add(kutu);
                }
                y += 80;
            }
        }

        private void PuzzlePage_Load(object sender, EventArgs e)
        {

        }

       
    }
}
