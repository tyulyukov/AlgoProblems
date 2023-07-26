using System.Diagnostics;

namespace ProjectGenerator;

public static class SolutionManager
{
    public static string GetSolutionPath()
    {
        var currentDirectory = Directory.GetCurrentDirectory();

        while (currentDirectory != null)
        {
            var solutionFiles = Directory.GetFiles(currentDirectory, "*.sln", SearchOption.TopDirectoryOnly);

            if (solutionFiles.Length > 0) return currentDirectory;

            currentDirectory = Directory.GetParent(currentDirectory)?.FullName;
        }

        throw new FileNotFoundException("Solution file (.sln) not found.");
    }
}