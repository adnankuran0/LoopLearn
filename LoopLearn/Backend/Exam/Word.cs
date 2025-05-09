using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopLearn.Backend.Quiz
{
    public class Word
    {
        public Word(int wordID, int userID, string engWordName, string turWordName, string picturePath, string audioPath) 
        {
            this.wordID = wordID;
            this.userID = userID;
            this.engWordName = engWordName;
            this.turWordName = turWordName;
            this.picturePath = picturePath;
            this.audioPath = audioPath;
        }

        public int wordID { get; set; }
        public int userID { get; set; }

        public string engWordName { get; set; }
        public string turWordName { get; set; }
        public string picturePath { get; set; }
        public string audioPath { get; set; }
    }
}
