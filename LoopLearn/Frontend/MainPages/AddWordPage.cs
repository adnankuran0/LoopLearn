using LoopLearn.Backend.Database;
using LoopLearn.Backend.Auth;
using LoopLearn.Backend.Utils;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LoopLearn.Frontend
{
    public partial class AddWordPage : UserControl
    {
        private string picturePath = "";
        private string audioPath = "";

        public AddWordPage()
        {
            InitializeComponent();
            Tag = "AddWord";
        }

        private void ChooseImage()
        {
            using var dialog = new OpenFileDialog
            {
                Title = "Bir görsel dosyası seç",
                Filter = "Görseller|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                picturePath = FileManager.CopyFileToBackend(dialog.FileName, "Pictures");
                string destinationPath = Path.Combine(
                    Directory.GetParent(Application.StartupPath).Parent.Parent.Parent.FullName, picturePath
                );
                pctSamplePicture.Image = Image.FromFile(destinationPath);
            }
        }

        private bool AreInputsValid()
        {
            if (string.IsNullOrEmpty(tbxEngWordName.Text) ||
                string.IsNullOrEmpty(tbxTurWordName.Text) ||
                string.IsNullOrEmpty(tbxSample.Text) ||
                string.IsNullOrEmpty(picturePath))
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (WordManager.WordExists(tbxEngWordName.Text))
            {
                MessageBox.Show("Bu kelime zaten mevcut!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ClearInputs();
                return false;
            }

            return true;
        }

        private void ClearInputs()
        {
            tbxEngWordName.Text = string.Empty;
            tbxTurWordName.Text = string.Empty;
            tbxSample.Text = string.Empty;
            pctSamplePicture.Image = null;
            picturePath = "";
            audioPath = "";
        }

        private void btnChoosePicture_Click(object sender, EventArgs e)
        {
            ChooseImage();
        }

        private void btnChooseAudio_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Title = "Bir ses dosyası seç",
                Filter = "Ses dosyaları|*.mp3;*.wav;*.ogg"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                audioPath = FileManager.CopyFileToBackend(dialog.FileName, "Audios");
            }
        }

        private void btnAddWord_Click(object sender, EventArgs e)
        {
            if (!AreInputsValid()) return;

            if (WordManager.TryAddWord(
                tbxEngWordName.Text,
                tbxTurWordName.Text,
                tbxSample.Text,
                picturePath,
                audioPath,
                out string message))
            {
                MessageBox.Show(message);
                ClearInputs();
            }
            else
            {
                MessageBox.Show(message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pctSamplePicture_Click(object sender, EventArgs e)
        {
            ChooseImage();
        }
    }
}