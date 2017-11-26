using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace bib
{
    internal class LicenseCommand : ICommand
    {
        public bool Execute()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            StreamReader reader = new StreamReader(assembly.GetManifestResourceStream("bib.License.txt"));
            Console.WriteLine(reader.ReadToEnd());
            return false;
        }
    }
}