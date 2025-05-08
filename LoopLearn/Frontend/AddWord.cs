using System;
using System.Collections.Generic;
using System.ComponentModel;
using LoopLearn.Backend.Database;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using LoopLearn.Backend.Auth;

namespace LoopLearn.Frontend
{
    public partial class AddWord : UserControl
    {
        private void ClearFields()
        {
            tbxEngWordName.Text = string.Empty;
            tbxTurWordName.Text = string.Empty;
            tbxSample.Text = string.Empty;
            pctSamplePicture.Image = null;
        }

        private string FixWord(string kelime)
        {
            if (string.IsNullOrWhiteSpace(kelime))
                return kelime;

            kelime = kelime.Trim();

            return char.ToUpper(kelime[0]) + kelime.Substring(1).ToLower();
        }

        private string picturePath = "";
        private string audioPath = "";

        public AddWord()
        {
            InitializeComponent();
            Tag = "AddWord";
        }

        private void btnChoosePicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Bir görsel dosyası seç";
            dialog.Filter = "Görseller|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = dialog.FileName;

                string solutionFolder = Directory.GetParent(Application.StartupPath).Parent.Parent.Parent.FullName;
                string picturesFolder = Path.Combine(solutionFolder, "Backend", "Database", "Pictures");

                if (!Directory.Exists(picturesFolder))
                    Directory.CreateDirectory(picturesFolder);

                string newFileName = Path.GetFileName(selectedPath);
                string destinationPath = Path.Combine(picturesFolder, newFileName);

                File.Copy(selectedPath, destinationPath, true);

                picturePath = Path.Combine("Backend", "Database", "Pictures", newFileName);

                Image img = Image.FromFile(destinationPath);
                pctSamplePicture.Image = img;
            }
        }

        private void btnChooseAudio_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Bir ses dosyası seç";
            dialog.Filter = "Ses dosyaları|*.mp3;*.wav;*.ogg";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = dialog.FileName;

                string solutionFolder = Directory.GetParent(Application.StartupPath).Parent.Parent.Parent.FullName;
                string audioFolder = Path.Combine(solutionFolder, "Backend", "Database", "Audios");

                if (!Directory.Exists(audioFolder))
                    Directory.CreateDirectory(audioFolder);

                string newFileName = Path.GetFileName(selectedPath);
                string destinationPath = Path.Combine(audioFolder, newFileName);

                File.Copy(selectedPath, destinationPath, true);

                audioPath = Path.Combine("Database", "Audio", newFileName);
            }
        }

        private void btnAddWord_Click(object sender, EventArgs e)
        {
            if (tbxEngWordName.Text == "" || tbxTurWordName.Text == "" || tbxSample.Text == "" || picturePath == "")
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Database.WordExists(FixWord(tbxEngWordName.Text)))
            {
                MessageBox.Show("Bu kelime zaten mevcut!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ClearFields();
                return;
            }

            int wordID = Database.AddWord(UserSession.UserId,FixWord(tbxEngWordName.Text), FixWord(tbxTurWordName.Text), picturePath, audioPath);
            Database.AddWordSample(wordID, tbxSample.Text);

            if (!string.IsNullOrEmpty(audioPath))
            {
                Database.AddWordAudio(wordID, audioPath);
            }
            MessageBox.Show("Kelime başarıyla eklendi!");
            ClearFields();
        }
    }
}
