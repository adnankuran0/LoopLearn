using LoopLearn.Backend.Database;
using LoopLearn.Backend.Quiz;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LoopLearn.Frontend
{
    public partial class PuzzlePage : UserControl
    {
        enum Direction
        {
            Horizontal,
            Vertical,
            Diagonal,
            HorizontalReverse,
            VerticalReverse,
            DiagonalReverse
        }

        private const int Rows = 6;
        private const int Cols = 5;
        private List<Label> cells = new List<Label>();
        private string[,] gridLetters = new string[Rows, Cols];
        private List<string> validWords;
        private string hiddenWord;
        private List<Point> selectedPositions = new List<Point>();

        public PuzzlePage()
        {
            InitializeComponent();
            this.Load += PuzzlePage_Load;
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
                    lbl.Font = new Font("Arial Black", 28, FontStyle.Bold);
                    lbl.BackColor = Color.White;
                    lbl.Tag = new Point(row, col);
                    lbl.Click += Cell_Click;
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

            bool placed = false;
            int tries = 0;
            const int maxTries = 1000;

            

            while (!placed && tries < maxTries)
            {
                ClearGrid();
                placed = PlaceRandomWordOnGrid();
                tries++;
            }

            

            if (!placed)
            {
                MessageBox.Show("Kelime yerleştirilemedi. Lütfen uygulamayı yeniden başlatın.");
                return;
            }

            FillGridWithRandomLetters();
            UpdateGridLabels();
        }

        private void ClearGrid()
        {
            for (int r = 0; r < Rows; r++)
                for (int c = 0; c < Cols; c++)
                    gridLetters[r, c] = null;
        }

        private bool PlaceRandomWordOnGrid()
        {
            Random rnd = new Random();

            var filteredWords = validWords.Where(w => w.Length >= 3 && w.Length <= 5).ToList();

            if (filteredWords.Count == 0)
            {
                MessageBox.Show("Uygun uzunlukta kelime bulunamadı.");
                return false;
            }

            hiddenWord = filteredWords[rnd.Next(filteredWords.Count)];
            int wordLength = hiddenWord.Length;

            Direction[] directions = (Direction[])Enum.GetValues(typeof(Direction));
            Direction dir = directions[rnd.Next(directions.Length)];

            int startX = 0;
            int startY = 0;
            bool placed = false;

            for (int attempt = 0; attempt < 100 && !placed; attempt++)
            {
                switch (dir)
                {
                    case Direction.Horizontal:
                        startX = rnd.Next(Cols - wordLength + 1);
                        startY = rnd.Next(Rows);
                        placed = TryPlaceWord(startX, startY, 1, 0, hiddenWord);
                        break;
                    case Direction.HorizontalReverse:
                        startX = rnd.Next(wordLength - 1, Cols);
                        startY = rnd.Next(Rows);
                        placed = TryPlaceWord(startX, startY, -1, 0, hiddenWord);
                        break;
                    case Direction.Vertical:
                        startX = rnd.Next(Cols);
                        startY = rnd.Next(Rows - wordLength + 1);
                        placed = TryPlaceWord(startX, startY, 0, 1, hiddenWord);
                        break;
                    case Direction.VerticalReverse:
                        startX = rnd.Next(Cols);
                        startY = rnd.Next(wordLength - 1, Rows);
                        placed = TryPlaceWord(startX, startY, 0, -1, hiddenWord);
                        break;
                    case Direction.Diagonal:
                        startX = rnd.Next(Cols - wordLength + 1);
                        startY = rnd.Next(Rows - wordLength + 1);
                        placed = TryPlaceWord(startX, startY, 1, 1, hiddenWord);
                        break;
                    case Direction.DiagonalReverse:
                        startX = rnd.Next(wordLength - 1, Cols);
                        startY = rnd.Next(wordLength - 1, Rows);
                        placed = TryPlaceWord(startX, startY, -1, -1, hiddenWord);
                        break;
                }
            }

            return placed;
        }

        private bool TryPlaceWord(int startX, int startY, int stepX, int stepY, string word)
        {
            int x = startX;
            int y = startY;

            for (int i = 0; i < word.Length; i++)
            {
                if (x < 0 || x >= Cols || y < 0 || y >= Rows)
                    return false;

                if (gridLetters[y, x] != null && gridLetters[y, x] != word[i].ToString())
                    return false;

                x += stepX;
                y += stepY;
            }

            x = startX;
            y = startY;
            for (int i = 0; i < word.Length; i++)
            {
                gridLetters[y, x] = word[i].ToString();
                x += stepX;
                y += stepY;
            }

            return true;
        }

        private void FillGridWithRandomLetters()
        {
            Random rnd = new Random();
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    if (string.IsNullOrEmpty(gridLetters[r, c]))
                        gridLetters[r, c] = ((char)rnd.Next('A', 'Z' + 1)).ToString();
                }
            }
        }

        private void UpdateGridLabels()
        {
            for (int i = 0; i < cells.Count; i++)
            {
                Point pos = (Point)cells[i].Tag;
                cells[i].Text = gridLetters[pos.X, pos.Y];
                cells[i].BackColor = Color.White;
            }
        }

        private void Cell_Click(object sender, EventArgs e)
        {
            if (!(sender is Label lbl)) return;
            Point pos = (Point)lbl.Tag;

            if (selectedPositions.Contains(pos))
            {
                selectedPositions.Remove(pos);
                lbl.BackColor = Color.White;
                return;
            }

            if (selectedPositions.Count == 0 || IsAdjacent(pos, selectedPositions.Last()))
            {
                selectedPositions.Add(pos);
                lbl.BackColor = Color.LightBlue;

                if (selectedPositions.Count == hiddenWord.Length)
                    CheckSelectedWord();
            }
            else
            {
                MessageBox.Show("Seçilen harfler bitişik olmalı ve sıralı seçilmeli.");
            }
        }

        private bool IsAdjacent(Point a, Point b)
        {
            int dx = Math.Abs(a.X - b.X);
            int dy = Math.Abs(a.Y - b.Y);

            return (dx <= 1 && dy <= 1) && !(dx == 0 && dy == 0);
        }

        private void CheckSelectedWord()
        {
            string selectedWord = "";
            foreach (var pos in selectedPositions)
                selectedWord += gridLetters[pos.X, pos.Y];

            if (selectedWord == hiddenWord)
            {
                MessageBox.Show("Tebrikler! Kelime doğru.");
                HighlightWord(Color.LightGreen);

                System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
                t.Interval = 1000;
                t.Tick += (s, e) =>
                {
                    t.Stop();
                    ResetGame();
                };
                t.Start();
            }
            else
            {
                MessageBox.Show("Yanlış kelime. Tekrar dene.");
                ClearSelection();
            }
        }

        private void HighlightWord(Color color)
        {
            foreach (var pos in selectedPositions)
            {
                var lbl = cells.First(c => ((Point)c.Tag).Equals(pos));
                lbl.BackColor = color;
            }
        }

        private void ClearSelection()
        {
            foreach (var pos in selectedPositions)
            {
                var lbl = cells.First(c => ((Point)c.Tag).Equals(pos));
                lbl.BackColor = Color.White;
            }
            selectedPositions.Clear();
        }

        private void ResetGame()
        {
            selectedPositions.Clear();
            ClearGrid();

            bool placed = false;
            int tries = 0;
            const int maxTries = 1000;

            while (!placed && tries < maxTries)
            {
                placed = PlaceRandomWordOnGrid();
                tries++;
            }

            if (!placed)
            {
                MessageBox.Show("Kelime yerleştirilemedi. Lütfen uygulamayı yeniden başlatın.");
                return;
            }

            FillGridWithRandomLetters();
            UpdateGridLabels();
        }
    }
}
