using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace bib
{
    internal class HoursCommand : ICommand
    {
        private List<string> args;

        public HoursCommand(List<string> args)
        {
            this.args = args;
        }

        public bool Execute()
        {
            string json = ApiRequest.Get("https://bib.kuleuven.be/apps/ub/blokkeninleuven/api/libraries/");
            List<Library> libraries = JsonConvert.DeserializeObject<List<Library>>(json);
            Library[] librariesArray;
            if (args.Contains("all")) librariesArray = libraries.ToArray();
            else librariesArray = libraries.Where(l => args.Contains(l.afk)).ToArray();
            json = JsonConvert.SerializeObject(librariesArray);
            //string pattern = @"""\d"":{""date"":""(\d{8})"",""begin"":""((?:\d{2}\.\d{2})?)"",""einde"":""((?:\d{2}\.\d{2})?)""";
            //string pattern = @"""hours"":(?:{ ""\d"":{ ""date"":""(\d{ 8})"",""begin"":""((?:\d{ 2}\.\d{ 2})?)"",""einde"":""((?:\d{ 2}\.\d{ 2})?)""},?){ 7}|\[\]";
            //string pattern = @"""hours"":(?:{(?:""\d"":{""date"":""(\d{8})"",""begin"":""((?:\d{1,2}\.\d{1,2}(?:-\d{1,2}\.\d{1,2})?)?)"",""einde"":""((?:\d{1,2}\.\d{1,2}(?:-\d{1,2}\.\d{1,2})?)?)""},?){ 7}})|\[\]";
            //string pattern = @"""\d"":{""date"":""(\d{8})"",""begin"":""((?:\d{1,2}\.\d{1,2}-\d{1,2}\.\d{1,2}|\d{1,2}\.\d{1,2})??(?:-\d{1,2}\.\d{1,2})?)"",""einde"":""((?:\d{1,2}\.\d{1,2}-\d{1,2}\.\d{1,2}|\d{1,2}\.\d{1,2})??(?:-\d{1,2}\.\d{1,2})?)""|\[\]";
            //string day = @"{""date"":""\d{8}"",""begin"":""(?:\d{1,2}\.\d{1,2}-\d{1,2}\.\d{1,2}|\d{1,2}\.\d{1,2})??"",""einde"":""(?:\d{1,2}\.\d{1,2}-\d{1,2}\.\d{1,2}|\d{1,2}\.\d{1,2})??""})";
            //string pattern = @"{""\d"":(?<Mon>{""date"":""\d{8}"",""begin"":""(?:\d{1,2}\.\d{1,2}-\d{1,2}\.\d{1,2}|\d{1,2}\.\d{1,2})??"",""einde"":""(?:\d{1,2}\.\d{1,2}-\d{1,2}\.\d{1,2}|\d{1,2}\.\d{1,2})??""}),""\d"":(?<Tue>{""date"":""\d{8}"",""begin"":""(?:\d{1,2}\.\d{1,2}-\d{1,2}\.\d{1,2}|\d{1,2}\.\d{1,2})??"",""einde"":""(?:\d{1,2}\.\d{1,2}-\d{1,2}\.\d{1,2}|\d{1,2}\.\d{1,2})??""}),""\d"":(?<Wed>{""date"":""\d{8}"",""begin"":""(?:\d{1,2}\.\d{1,2}-\d{1,2}\.\d{1,2}|\d{1,2}\.\d{1,2})??"",""einde"":""(?:\d{1,2}\.\d{1,2}-\d{1,2}\.\d{1,2}|\d{1,2}\.\d{1,2})??""}),""\d"":(?<Thu>{""date"":""\d{8}"",""begin"":""(?:\d{1,2}\.\d{1,2}-\d{1,2}\.\d{1,2}|\d{1,2}\.\d{1,2})??"",""einde"":""(?:\d{1,2}\.\d{1,2}-\d{1,2}\.\d{1,2}|\d{1,2}\.\d{1,2})??""}),""\d"":(?<Fri>{""date"":""\d{8}"",""begin"":""(?:\d{1,2}\.\d{1,2}-\d{1,2}\.\d{1,2}|\d{1,2}\.\d{1,2})??"",""einde"":""(?:\d{1,2}\.\d{1,2}-\d{1,2}\.\d{1,2}|\d{1,2}\.\d{1,2})??""}),""\d"":(?<Sat>{""date"":""\d{8}"",""begin"":""(?:\d{1,2}\.\d{1,2}-\d{1,2}\.\d{1,2}|\d{1,2}\.\d{1,2})??"",""einde"":""(?:\d{1,2}\.\d{1,2}-\d{1,2}\.\d{1,2}|\d{1,2}\.\d{1,2})??""}),""\d"":(?<Sun>{""date"":""\d{8}"",""begin"":""(?:\d{1,2}\.\d{1,2}-\d{1,2}\.\d{1,2}|\d{1,2}\.\d{1,2})??"",""einde"":""(?:\d{1,2}\.\d{1,2}-\d{1,2}\.\d{1,2}|\d{1,2}\.\d{1,2})??""})}";

            string pattern = @"{""\d"":(?<Mon>{""date"":""\d{8}"",""begin"":""(?:\d{1,2}\.\d{1,2}-\d{1,2}\.\d{1,2}|\d{1,2}\.\d{1,2})?"",""einde"":""(?:\d{1,2}\.\d{1,2}-\d{1,2}\.\d{1,2}|\d{1,2}\.\d{1,2})??""}),""\d"":(?<Tue>{""date"":""\d{8}"",""begin"":""(?:\d{1,2}\.\d{1,2}-\d{1,2}\.\d{1,2}|\d{1,2}\.\d{1,2})??"",""einde"":""(?:\d{1,2}\.\d{1,2}-\d{1,2}\.\d{1,2}|\d{1,2}\.\d{1,2})??""}),""\d"":(?<Wed>{""date"":""\d{8}"",""begin"":""(?:\d{1,2}\.\d{1,2}-\d{1,2}\.\d{1,2}|\d{1,2}\.\d{1,2})??"",""einde"":""(?:\d{1,2}\.\d{1,2}-\d{1,2}\.\d{1,2}|\d{1,2}\.\d{1,2})??""}),""\d"":(?<Thu>{""date"":""\d{8}"",""begin"":""(?:\d{1,2}\.\d{1,2}-\d{1,2}\.\d{1,2}|\d{1,2}\.\d{1,2})??"",""einde"":""(?:\d{1,2}\.\d{1,2}-\d{1,2}\.\d{1,2}|\d{1,2}\.\d{1,2})??""}),""\d"":(?<Fri>{""date"":""\d{8}"",""begin"":""(?:\d{1,2}\.\d{1,2}-\d{1,2}\.\d{1,2}|\d{1,2}\.\d{1,2})??"",""einde"":""(?:\d{1,2}\.\d{1,2}-\d{1,2}\.\d{1,2}|\d{1,2}\.\d{1,2})??""}),""\d"":(?<Sat>{""date"":""\d{8}"",""begin"":""(?:\d{1,2}\.\d{1,2}-\d{1,2}\.\d{1,2}|\d{1,2}\.\d{1,2})??"",""einde"":""(?:\d{1,2}\.\d{1,2}-\d{1,2}\.\d{1,2}|\d{1,2}\.\d{1,2})??""}),""\d"":(?<Sun>{""date"":""\d{8}"",""begin"":""(?:\d{1,2}\.\d{1,2}-\d{1,2}\.\d{1,2}|\d{1,2}\.\d{1,2})??"",""einde"":""(?:\d{1,2}\.\d{1,2}-\d{1,2}\.\d{1,2}|\d{1,2}\.\d{1,2})??""})}";

            string replacement = "[${Mon}, ${Tue}, ${Wed}, ${Thu}, ${Fri}, ${Sat}, ${Sun}]";
            string formattedJson = Regex.Replace(json, pattern, replacement);
            List<FormattedLibrary> formattedLibraries = JsonConvert.DeserializeObject<List<FormattedLibrary>>(formattedJson);
            FormattedLibrary[] formattedLibrariesArray = formattedLibraries.ToArray();

            //foreach ()
            //{
            //    Console.WriteLine(match.Groups[0]);
            //    DateTime originalDate = DateTime.ParseExact(match.Groups[1].ToString(), "yyyyMMdd", CultureInfo.CreateSpecificCulture("en-US"));
            //    DateTime today = DateTime.Today;
            //    if(today.ToString("yyyyMMdd").Equals(match.Groups[1].ToString())) Console.WriteLine(originalDate.ToString("ddd") + "\t" + match.Groups[2] + " - " + match.Groups[3] + "\t<-");
            //    else Console.WriteLine(originalDate.ToString("ddd") + "\t" + match.Groups[2] + " - " + match.Groups[3]);
            //}
            //json.Replace({ "1":{ "date":"20171120","begin":"08.30","einde":"22.00"},"2":{ "date":"20171121","begin":"08.30","einde":"22.00"},"3":{ "date":"20171122","begin":"08.30","einde":"22.00"},"4":{ "date":"20171123","begin":"08.30","einde":"22.00"},"5":{ "date":"20171124","begin":"8.30","einde":"18.00"},"6":{ "date":"20171125","begin":"9.00","einde":"13.00"},"7":{ "date":"20171126","begin":"","einde":""} });
            // Ugly but it helps :)
            // json = json.Replace("\"1\"", "\"Ma\"").Replace("\"2\"", "\"Di\"").Replace("\"3\"", "\"Wo\"").Replace("\"4\"", "\"Do\"").Replace("\"5\"", "\"Vr\"").Replace("\"6\"", "\"Za\"").Replace("\"7\"", "\"Zo\"");
            //Console.WriteLine(json);
            //List < Library > libraries = JsonConvert.DeserializeObject<List<Library>>(json);
            //Library[] librariesArray;
            //if (args.Contains("all")) librariesArray = libraries.ToArray();
            //else librariesArray = libraries.Where(l => args.Contains(l.afk)).ToArray();

            foreach (FormattedLibrary library in formattedLibrariesArray)
            {
                Console.WriteLine(library.naam);
                Day[] hours = library.hours;
                if (hours.Length == 0)
                    continue;

                Console.WriteLine("Ma\t" + library.hours[0].begin + " - " + library.hours[0].einde);
                Console.WriteLine("Do\t" + library.hours[1].begin + " - " + library.hours[1].einde);
                Console.WriteLine("Wo\t" + library.hours[2].begin + " - " + library.hours[2].einde);
                Console.WriteLine("Do\t" + library.hours[3].begin + " - " + library.hours[3].einde);
                Console.WriteLine("Vr\t" + library.hours[4].begin + " - " + library.hours[4].einde);
                Console.WriteLine("Za\t" + library.hours[5].begin + " - " + library.hours[5].einde);
                Console.WriteLine("Zo\t" + library.hours[6].begin + " - " + library.hours[6].einde);
                Console.WriteLine();
            }
            return false;
        }
    }
}