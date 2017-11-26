using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace bib
{
    internal class AfkCommand : ICommand
    {
        public bool Execute()
        {

            string json = ApiRequest.Get("https://bib.kuleuven.be/apps/ub/blokkeninleuven/api/libraries/");
            json = json.Replace("\"1\"", "\"Ma\"").Replace("\"2\"", "\"Di\"").Replace("\"3\"", "\"Wo\"").Replace("\"4\"", "\"Do\"").Replace("\"5\"", "\"Vr\"").Replace("\"6\"", "\"Za\"").Replace("\"7\"", "\"Zo\"");
            List<Library> libraries = JsonConvert.DeserializeObject<List<Library>>(json);
            Library[] librariesArray = libraries.ToArray();

            foreach (Library library in librariesArray)
            {
                Console.WriteLine(library.naam + "\t" + library.afk);
            }
            return false;
        }
    }
}