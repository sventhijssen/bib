using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bib
{
    public static class Parser
    {
        public static ICommand Parse(string commandString)
        {
            // Parse your string and create Command object
            var commandParts = commandString.Split(' ').ToList();
            var commandName = commandParts[0];
            var args = commandParts.Skip(1).ToList(); // The arguments list after the command
            if (args.Any(str => str.Contains("--help")))
                return new HelpCommand(commandName);
            switch (commandName)
            {
                // Create command based on CommandName (and maybe arguments)
                case "exit": return new ExitCommand();
                case "help": return new HelpCommand();
                case "clear": return new ClearCommand();
                case "license": return new LicenseCommand();
                case "show": return new ShowCommand(args);
                case "afk": return new AfkCommand();
                case "hours": return new HoursCommand(args);
                default:
                    return new DefaultCommand();
            }
        }
    }
}
