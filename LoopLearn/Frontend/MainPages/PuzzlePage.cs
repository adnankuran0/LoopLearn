using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoopLearn.Backend.Quiz;
using System.Windows.Forms;
using System.Diagnostics.Tracing;
using System.Data.Entity;
using LoopLearn.Backend.Database;

namespace LoopLearn.Frontend
{
    public partial class PuzzlePage : UserControl
    {
        private const int Rows = 6;
        private const int Cols = 5;
        private List<Label> cells = new List<Label>();
        private int currentRow = 0;
        private int currentCol = 0;
        private string targetWord;
        private List<string> validWords;

        public PuzzlePage()
        {
            InitializeComponent();
            this.KeyPress += PuzzlePage_KeyPress;
             this.Load += PuzzlePage_Load;
            this.SetStyle(ControlStyles.Selectable, true);
            this.TabStop = true;

            CreateGrid();
            LoadWordsFromDatabase();

          
        }

        private void PuzzlePage_Load(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void CreateGrid()
        {
            int boxSize = 70;
            int spacing = 12;
            int totalWidth = Cols * boxSize + (Cols - 1) * spacing;
            int startX = ((this.Width - totalWidth) / 2) - 150;
            int startY = 125;

            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Cols; col++)
                {
                    Label lbl = new Label();
                    lbl.Size = new Size(boxSize, boxSize);
                    lbl.Location = new Point(startX + col * (boxSize + spacing), startY + row * (boxSize + spacing));
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.BorderStyle = BorderStyle.FixedSingle;
                    lbl.Font = new Font("Consolas", 28, FontStyle.Bold);
                    lbl.BackColor = Color.White;
                    this.Controls.Add(lbl);
                    cells.Add(lbl);
                }
            }
        }

        private void LoadWordsFromDatabase()
        {
            List<Word> wordsFromDb = DatabaseService.Instance.wordRepository.GetKnownWords(60, 5);
            if (wordsFromDb == null || wordsFromDb.Count == 0)
            {
                MessageBox.Show("Veritabanından kelime alınamadı.");
                return;
            }

            validWords = wordsFromDb.Select(w => w.engWordName.ToUpper()).ToList();

            
            Random rnd = new Random();
            targetWord = validWords[rnd.Next(validWords.Count)];
        }

        private void PuzzlePage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && currentCol < Cols)
            {
                cells[currentRow * Cols + currentCol].Text = char.ToUpper(e.KeyChar).ToString();
                currentCol++;
            }
            else if (e.KeyChar == '\b' && currentCol > 0) // Backspace için
            {
                currentCol--;
                cells[currentRow * Cols + currentCol].Text = "";
            }
            else if (e.KeyChar == (char)Keys.Enter && currentCol == Cols)
            {
                string guess = "";
                for (int i = 0; i < Cols; i++)
                    guess += cells[currentRow * Cols + i].Text;

                if (!validWords.Contains(guess))
                {
                    MessageBox.Show("Geçerli bir kelime gir.");
                    return;
                }

                CheckGuess(guess);
                if (guess == targetWord)
                {
                    MessageBox.Show("Tebrikler! Bildin.");
                    this.Enabled = false;
                    return;
                }

                currentRow++;
                currentCol = 0;

                if (currentRow >= Rows)
                {
                    MessageBox.Show($"Oyun bitti! Kelime: {targetWord}");
                    this.Enabled = false;
                }
            }
        }

        private void CheckGuess(string guess)
        {
            for (int i = 0; i < Cols; i++)
            {
                var label = cells[currentRow * Cols + i];
                char letter = guess[i];

                if (targetWord[i] == letter)
                {
                    label.BackColor = Color.Green;
                }
                else if (targetWord.Contains(letter))
                {
                    label.BackColor = Color.Gold;
                }
                else
                {
                    label.BackColor = Color.LightGray;
                }
            }
        }
    }
}
