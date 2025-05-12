
namespace LoopLearn.Backend.Utils
{
    public class FileManager
    {
        public static string CopyFileToBackend(string sourcePath, string folderName)
        {

            string solutionFolder = Directory.GetParent(Application.StartupPath).Parent.Parent.Parent.FullName;
            string targetFolder = Path.Combine(solutionFolder, "Backend", "Database", folderName);

            Directory.CreateDirectory(targetFolder);

            string fileName = Path.GetFileName(sourcePath);
            string destination = Path.Combine(targetFolder, fileName);

            File.Copy(sourcePath, destination, true);

            return Path.Combine("Backend", "Database", folderName, fileName);
        }
    }
}
