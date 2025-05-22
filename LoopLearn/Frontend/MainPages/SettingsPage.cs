using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LoopLearn.Frontend
{
    public partial class SettingsPage : UserControl
    {
        public SettingsPage()
        {
            InitializeComponent();
            Tag = "Settings";

            comboBox2.Items.AddRange(new object[] { 5, 10, 15, 20, 30 });
            int savedValue = Properties.Settings.Default.DailyNewWordCount;

            if (comboBox2.Items.Contains(savedValue))
            {
                comboBox2.SelectedItem = savedValue;
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DailyNewWordCount = Convert.ToInt32(comboBox2.SelectedItem);
            Properties.Settings.Default.Save();
        }
    }
}
