using LoopLearn.Backend.Auth;
using LoopLearn.Backend.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LoopLearn.Backend.Utils
{
    public class WordManager
    {
        public static string FixWord(string kelime)
        {
            if (string.IsNullOrWhiteSpace(kelime))
                return kelime;

            kelime = kelime.Trim();
            return char.ToUpper(kelime[0]) + kelime.Substring(1).ToLower();
        }

        public static bool WordExists(string word)
        {
            return DatabaseManager.WordExists(FixWord(word));
        }

        public static bool TryAddWord(string engRaw, string turRaw, string sample, string picturePath, string audioPath, out string message)
        {
            string eng = FixWord(engRaw);
            string tur = FixWord(turRaw);

            if (DatabaseManager.WordExists(eng))
            {
                message = "Bu kelime zaten mevcut!";
                return false;
            }

            int wordID = DatabaseManager.AddWord(UserSession.Instance.UserId , eng, tur, picturePath, audioPath);
            DatabaseManager.AddWordSample(wordID, sample);

            if (!string.IsNullOrWhiteSpace(audioPath))
                DatabaseManager.AddWordAudio(wordID, audioPath);

            message = "Kelime başarıyla eklendi!";
            return true;
        }
    }
}
