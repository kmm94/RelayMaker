using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelayMaker.Data
{
    class Swimmer
    {
        public Swimmer(int swimmer_id, String swimmer_name, int swimmer_yob, int status, String club_name, String swimmer_name_link)
        {
            this.Id = swimmer_id;
            this.Name = swimmer_name;
            this.YearOfBirth = swimmer_yob;
            this.Status = status;
            this.Club = club_name;
        }

        public int Id { get;  }
        public String Name { get; } 
        public int YearOfBirth { get; }
        public int Status { get; }
        public String Club { get; }

        public List<Race> Races { get; set; }

    }
}
