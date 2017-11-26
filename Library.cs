using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bib
{
    public class Library
    {
        public string id { get; set; }
        public string naam { get; set; }
        public string naam_eng { get; set; }
        public string naam_kort { get; set; }
        public string naam_kort_eng { get; set; }
        public string afk { get; set; }
        public string blokpagina { get; set; }
        public string top { get; set; }
        public string locatie { get; set; }
        public string url_nl { get; set; }
        public string bib_url_eng { get; set; }
        public int zitjes { get; set; }
        public string image { get; set; }
        public string adres { get; set; }
        public string facebook { get; set; }
        public string twitter { get; set; }
        public string geolocation { get; set; }
        public object occupancy { get; set; }
        public object group { get; set; }
        public Faculty faculty { get; set; }
        public object hours { get; set; }
        public int gesloten { get; set; }
    }

    public class FormattedLibrary
    {
        public string id { get; set; }
        public string naam { get; set; }
        public string naam_eng { get; set; }
        public string naam_kort { get; set; }
        public string naam_kort_eng { get; set; }
        public string afk { get; set; }
        public string blokpagina { get; set; }
        public string top { get; set; }
        public string locatie { get; set; }
        public string url_nl { get; set; }
        public string bib_url_eng { get; set; }
        public int zitjes { get; set; }
        public string image { get; set; }
        public string adres { get; set; }
        public string facebook { get; set; }
        public string twitter { get; set; }
        public string geolocation { get; set; }
        public object occupancy { get; set; }
        public object group { get; set; }
        public Faculty faculty { get; set; }
        public Day[] hours { get; set; }
        public int gesloten { get; set; }
    }
}
