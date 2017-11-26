using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace bib
{
    internal class ShowCommand : ICommand
    {
        private List<string> args;

        public ShowCommand(List<string> args)
        {
            this.args = args;
        }

        public bool Execute()
        {
            string json = ApiRequest.Get("https://bib.kuleuven.be/apps/ub/blokkeninleuven/api/libraries/");
            List<Library> libraries = JsonConvert.DeserializeObject<List<Library>>(json);
            json = json.Replace("\"1\"", "\"Ma\"").Replace("\"2\"", "\"Di\"").Replace("\"3\"", "\"Wo\"").Replace("\"4\"", "\"Do\"").Replace("\"5\"", "\"Vr\"").Replace("\"6\"", "\"Za\"").Replace("\"7\"", "\"Zo\"");
            Library[] librariesArray;
            if (args.Contains("all")) librariesArray = libraries.ToArray();
            else librariesArray = libraries.Where(l => args.Contains(l.afk)).ToArray();

            foreach (Library library in librariesArray)
            {
                Console.WriteLine(library.naam + "\t" + library.occupancy + "/" + library.zitjes);
            }
            return false;
        }
    }
}
