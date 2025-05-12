using LoopLearn.Backend.Auth;
using LoopLearn.Backend.Database;
using LoopLearn.Backend.Quiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
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
            return DatabaseService.Instance.wordRepository.WordExists(FixWord(word));
        }

        public static bool TryAddWord(string engRaw, string turRaw, string sample, string picturePath, string audioPath, out string message)
        {
            string eng = FixWord(engRaw);
            string tur = FixWord(turRaw);

            if (DatabaseService.Instance.wordRepository.WordExists(eng))
            {
                message = "Bu kelime zaten mevcut!";
                return false;
            }

            int wordID = DatabaseService.Instance.wordRepository.AddWord(eng, tur, picturePath, audioPath);
            DatabaseService.Instance.wordRepository.AddWordSample(wordID, sample);

            if (!string.IsNullOrWhiteSpace(audioPath))
                DatabaseService.Instance.wordRepository.AddWordAudio(wordID, audioPath);

            message = "Kelime başarıyla eklendi!";
            return true;
        }

        public static int GetWordCount()
        {
            return DatabaseService.Instance.wordRepository.GetWordCount();
        }

        public static Word? GetWordByID(int ID)
        {
            return DatabaseService.Instance.wordRepository.GetWordByID(ID);
        }

        public static Word GetUniqueRandomWord(HashSet<int> excludeIDs)
        {
            return DatabaseService.Instance.wordRepository.GetUniqueRandomWord(excludeIDs);
        }
    }
}
