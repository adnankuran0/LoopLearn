using LoopLearn.Frontend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopLearn.Backend.Utils
{
    public static class PageManager
    {
        private static MainForm m_MainForm;

        public static void Initalize(MainForm mainForm)
        {
            m_MainForm = mainForm;
        }

        public static void LoadPage(UserControl page)
        {
            if (m_MainForm == null) return;

            m_MainForm.panelMain.Controls.Clear();
            page.Dock = DockStyle.Fill;
            m_MainForm.panelMain.Controls.Add(page);
        }

    }
}
