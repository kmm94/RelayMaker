using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelayMaker.Data
{
    class Race
    {



        Style style;
        int distance;
        String time;
        int finaPoints;
        int swimDevelomentPoints;
        DateTime date;

        public Race(Style style, int distance, string time, int finaPoints, int swimDevelomentPoints, DateTime date)
        {
            this.style = style;
            this.distance = distance;
            this.time = time;
            this.finaPoints = finaPoints;
            this.swimDevelomentPoints = swimDevelomentPoints;
            this.date = date;
        }
    }
}
