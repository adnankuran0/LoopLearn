namespace LoopLearn.Frontend
{
    partial class AddWord
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tbxEngWordName = new TextBox();
            tbxTurWordName = new TextBox();
            tbxSample = new TextBox();
            lblEngWordName = new Label();
            lblTurWordName = new Label();
            lblSample = new Label();
            btnAddWord = new Button();
            btnChoosePicture = new Button();
            btnChooseVoice = new Button();
            pctSamplePicture = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pctSamplePicture).BeginInit();
            SuspendLayout();
            // 
            // tbxEngWordName
            // 
            tbxEngWordName.Location = new Point(310, 216);
            tbxEngWordName.Name = "tbxEngWordName";
            tbxEngWordName.Size = new Size(230, 23);
            tbxEngWordName.TabIndex = 0;
            // 
            // tbxTurWordName
            // 
            tbxTurWordName.Location = new Point(310, 269);
            tbxTurWordName.Name = "tbxTurWordName";
            tbxTurWordName.Size = new Size(230, 23);
            tbxTurWordName.TabIndex = 1;
            // 
            // tbxSample
            // 
            tbxSample.Location = new Point(310, 321);
            tbxSample.Name = "tbxSample";
            tbxSample.Size = new Size(230, 23);
            tbxSample.TabIndex = 2;
            // 
            // lblEngWordName
            // 
            lblEngWordName.AutoSize = true;
            lblEngWordName.BackColor = Color.Transparent;
            lblEngWordName.ForeColor = Color.White;
            lblEngWordName.Location = new Point(213, 219);
            lblEngWordName.Name = "lblEngWordName";
            lblEngWordName.Size = new Size(91, 15);
            lblEngWordName.TabIndex = 3;
            lblEngWordName.Text = "İngilizce kelime:";
            // 
            // lblTurWordName
            // 
            lblTurWordName.AutoSize = true;
            lblTurWordName.BackColor = Color.Transparent;
            lblTurWordName.ForeColor = Color.White;
            lblTurWordName.Location = new Point(194, 272);
            lblTurWordName.Name = "lblTurWordName";
            lblTurWordName.Size = new Size(110, 15);
            lblTurWordName.TabIndex = 4;
            lblTurWordName.Text = "Kelimenin Türkçesi:";
            // 
            // lblSample
            // 
            lblSample.AutoSize = true;
            lblSample.BackColor = Color.Transparent;
            lblSample.ForeColor = Color.White;
            lblSample.Location = new Point(222, 324);
            lblSample.Name = "lblSample";
            lblSample.Size = new Size(82, 15);
            lblSample.TabIndex = 5;
            lblSample.Text = "Cümle örneği:";
            // 
            // btnAddWord
            // 
            btnAddWord.Location = new Point(310, 426);
            btnAddWord.Name = "btnAddWord";
            btnAddWord.Size = new Size(230, 28);
            btnAddWord.TabIndex = 6;
            btnAddWord.Text = "Kelime Ekle";
            btnAddWord.UseVisualStyleBackColor = true;
            btnAddWord.Click += btnAddWord_Click;
            // 
            // btnChoosePicture
            // 
            btnChoosePicture.Location = new Point(310, 388);
            btnChoosePicture.Name = "btnChoosePicture";
            btnChoosePicture.Size = new Size(99, 23);
            btnChoosePicture.TabIndex = 7;
            btnChoosePicture.Text = "Görsel seç";
            btnChoosePicture.UseVisualStyleBackColor = true;
            btnChoosePicture.Click += btnChoosePicture_Click;
            // 
            // btnChooseVoice
            // 
            btnChooseVoice.Location = new Point(441, 388);
            btnChooseVoice.Name = "btnChooseVoice";
            btnChooseVoice.Size = new Size(99, 23);
            btnChooseVoice.TabIndex = 8;
            btnChooseVoice.Text = "Ses seç (?)";
            btnChooseVoice.UseVisualStyleBackColor = true;
            // 
            // pctSamplePicture
            // 
            pctSamplePicture.BackColor = Color.Gray;
            pctSamplePicture.Location = new Point(584, 216);
            pctSamplePicture.Name = "pctSamplePicture";
            pctSamplePicture.Size = new Size(236, 238);
            pctSamplePicture.SizeMode = PictureBoxSizeMode.Zoom;
            pctSamplePicture.TabIndex = 9;
            pctSamplePicture.TabStop = false;
            pctSamplePicture.Click += pctSamplePicture_Click;
            // 
            // AddWord
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.LoginPageBackground;
            Controls.Add(pctSamplePicture);
            Controls.Add(btnChooseVoice);
            Controls.Add(btnChoosePicture);
            Controls.Add(btnAddWord);
            Controls.Add(lblSample);
            Controls.Add(lblTurWordName);
            Controls.Add(lblEngWordName);
            Controls.Add(tbxSample);
            Controls.Add(tbxTurWordName);
            Controls.Add(tbxEngWordName);
            Name = "AddWord";
            Size = new Size(1039, 676);
            ((System.ComponentModel.ISupportInitialize)pctSamplePicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbxEngWordName;
        private TextBox tbxTurWordName;
        private TextBox tbxSample;
        private Label lblEngWordName;
        private Label lblTurWordName;
        private Label lblSample;
        private Button btnAddWord;
        private Button btnChoosePicture;
        private Button btnChooseVoice;
        private PictureBox pctSamplePicture;
    }
}
