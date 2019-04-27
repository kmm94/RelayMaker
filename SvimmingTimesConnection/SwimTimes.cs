using HtmlAgilityPack;
using Newtonsoft.Json;
using RelayMaker.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RelayMaker.SvimmingTimesConnection
{
    class SwimTimes
    {
        private static SwimTimes instance;

        private SwimTimes()
        {
            LoadeData();
        }

        public static SwimTimes GetInstance()
        {
            if (instance == null)
            {
                instance = new SwimTimes();

            }
            return instance;

        }

        private void LoadeData()
        {
            string jsonString = File.ReadAllText(@"Data\SwimmerTable.json");
            JsonConvert.DeserializeObject(jsonString);
        }

        //String Html = new System.Net.WebClient().DownloadString(siteUrl);

        private int getSwimmmerID(String name)
        {
            return 1;
        }

        public Swimmer GetSwimmersTimes(Swimmer swimmer)
        {
            HtmlDocument htmlPage = GetHTMLPage(swimmer);
            swimmer = GetRaceTimes(swimmer, htmlPage);

            return swimmer;
        }

        private Swimmer GetRaceTimes(Swimmer swimmer, HtmlDocument htmlPage)
        {

            List<Race> races = new List<Race>();
            var tables = htmlPage.DocumentNode.SelectNodes("//table");
            for(int i = 0; i < tables.Count; i++)
                //(HtmlNode table in tables.Elements("tbody"))
            {
                HtmlNode table = tables.Elements("tbody").ElementAt(i);
                if (table.SelectNodes("tr") != null)
                {
                    foreach (HtmlNode row in table.SelectNodes("tr"))
                    {
                        Race race = GetRaceFromRow(row);
                        if(i == 0)
                        {
                            race.isLongCourse = false;
                        } else
                        {
                            race.isLongCourse = true;
                        }
                        races.Add(race);
                    }
                }

            }
            swimmer.Races = races;
            return swimmer;
        }

        private Race GetRaceFromRow(HtmlNode row)
        {
            var rows = row.SelectNodes("th|td");
            var race = new Race();

            race.style = rows.ElementAt(0).InnerText.Split(' ')[1];
            race.distance = int.Parse(rows.ElementAt(0).InnerText.Split(' ')[0]);

            var stringTime = rows.ElementAt(1).InnerText;
            if (stringTime.Contains(":"))
            {
                var timeArray = rows.ElementAt(1).InnerText.Split(':');
                var minuts = int.Parse(timeArray[0]);
                timeArray = timeArray[1].Split('.');
                var seconds = int.Parse(timeArray[0]);
                var hundres = int.Parse(timeArray[1]);
                race.time = new TimeSpan(0, 0, minuts, seconds, hundres * 10);

            }
            else
            {
                var timeArray = stringTime.Split('.');
                var seconds = int.Parse(timeArray[0]);
                var hundres = int.Parse(timeArray[1]);
                race.time = new TimeSpan(0, 0, 0, seconds, hundres * 10);
            }

            if (!rows.ElementAt(2).InnerText.Equals(""))
            {
                race.finaPoints = int.Parse(rows.ElementAt(2).InnerText);
            }
            if (!rows.ElementAt(3).InnerText.Equals(""))
            {
                race.swimDevelomentPoints = int.Parse(rows.ElementAt(3).InnerText);
            }
            race.date = DateTime.Parse(rows.ElementAt(4).InnerText);
            return race;
        }

        private HtmlDocument GetHTMLPage(Swimmer swimmer)
        {
            var url = "https://xn--svmmetider-1cb.dk/svoemmer/?" + swimmer.Id;
            var web = new HtmlWeb();
            var doc = web.Load(url);
            return doc;
        }
    }
}
