using System;

namespace bib
{
    internal class DefaultCommand : ICommand
    {
        public bool Execute()
        {
            Console.WriteLine("Unknown internal command. Type \"help\" for more information.");
            return false;
        }
    }
}