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
            //HtmlNode table = htmlPage.DocumentNode.Element("DataTables_Table_0");
            List<Race> races = new List<Race>();
            var table2 = htmlPage.DocumentNode.SelectNodes("//table");
            foreach (HtmlNode table in table2.Elements("tbody")) 
            {
                Console.WriteLine("Found: " + table.Id);
                //TODO: If table is empty
                foreach (HtmlNode row in table.SelectNodes("tr"))
                {
                    Console.WriteLine("row");
                    foreach (HtmlNode cell in row.SelectNodes("th|td"))
                    {
                        Console.WriteLine("cell: " + cell.InnerText);
                    }
                }
            }

            //var divWithTimes = (from bar in htmlPage.DocumentNode.Descendants()
            //           where bar.GetAttributeValue("id", null) == "k_content_body"
            //                    select bar).FirstOrDefault();
            //var list = divWithTimes.Descendants();
            //var shortCourseTimeTable = divWithTimes.GetClasses();
            return swimmer;
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
