using System.Text.RegularExpressions;
using CliWrap;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectGenerator;
using Spectre.Console;

var settings = JsonConvert.DeserializeObject<JObject>(File.ReadAllText("appsettings.json"))!;
var platforms = settings["platforms"]!.ToObject<List<Platform>>();

var selector = new SelectionPrompt<Platform>()
    .Title("[yellow]What platform do you want to create a project with?[/]")
    .AddChoices(platforms!)
    .UseConverter(p => p.DisplayName);

var platform = AnsiConsole.Prompt(selector);
var task = AnsiConsole.Prompt(new TextPrompt<string>("[yellow]Write a name of the task[/]"));

var projectName = GenerateProjectName(platform, task);

AnsiConsole.MarkupLine($"The name of the project is [yellow]{projectName}[/]");

var thatsAlright = AnsiConsole.Prompt(new ConfirmationPrompt("[blue]Is the name of the project fine?[/]"));

if (!thatsAlright)
    projectName = AnsiConsole.Prompt(new TextPrompt<string>("[yellow]Write a new name of the project[/]"));

try
{
    await AnsiConsole.Status()
        .Spinner(Spinner.Known.Aesthetic)
        .StartAsync("Creating", async ctx =>
        {
            try
            {
                var solutionDirectory = SolutionManager.GetSolutionPath();
                
                await Cli.Wrap("dotnet")
                    .WithArguments($"new console -n {projectName}")
                    .WithWorkingDirectory(solutionDirectory)
                    .ExecuteAsync();
                
                await Cli.Wrap("dotnet")
                    .WithArguments($"sln add {projectName}")
                    .WithWorkingDirectory(solutionDirectory)
                    .ExecuteAsync();

                await File.WriteAllTextAsync(Path.Combine(solutionDirectory, projectName, "Program.cs"),
                    """
                    var s = new Solution();
                    Console.WriteLine("I love my mom!");
                    
                    public class Solution
                    {
                        
                    }
                    """);

                AnsiConsole.WriteLine("Done.");
                AnsiConsole.WriteLine();
                
                AnsiConsole.Write(new FigletText("Happy").Color(Color.Blue));
                AnsiConsole.Write(new FigletText("hacking!").Color(Color.Yellow));
            }
            catch
            {
                AnsiConsole.MarkupLine("An [red]error[/] has occurred while creating new project");
                throw;
            }
        });
}
catch (Exception ex)
{
    AnsiConsole.WriteException(ex);
}

string GenerateProjectName(Platform p, string taskName) => 
    $"{p.ShortCode}-{Regex.Replace(taskName, @"[^a-zA-Z0-9\s]", "").Replace(' ', '-').ToLower()}";