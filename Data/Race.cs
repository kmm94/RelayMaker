using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace RelayMaker.Data
{
    class Race
    {



        public String style { get; set; }
        public int distance { get; set; }
        public TimeSpan time { get; set; }
        public int finaPoints { get; set; }
        public int swimDevelomentPoints { get; set; }
        public DateTime date { get; set; }
        public bool isLongCourse { get; set; }


       
        public Race(String style, int distance, TimeSpan time, int finaPoints, int swimDevelomentPoints, DateTime date)
        {
            this.style = style;
            this.distance = distance;
            this.time = time; //TODO make a time type o be able to compare times
            if (!finaPoints.Equals(""))
            {
                this.finaPoints = finaPoints;
            }

            if (!swimDevelomentPoints.Equals("")){
                this.swimDevelomentPoints = swimDevelomentPoints;
            }
            this.date = date;
        }

        public Race()
        {
        }



    }
}
