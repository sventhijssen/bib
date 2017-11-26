using System;

namespace bib
{
    class ClearCommand : ICommand
    {
        public bool Execute()
        {
            Console.Clear();
            return false;
        }
    }
}