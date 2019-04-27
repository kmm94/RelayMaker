using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RelayMaker.Data;
using RelayMaker.SvimmingTimesConnection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace RelayMaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Click on the link below to continue learning how to build a desktop app using WinForms!
            System.Diagnostics.Process.Start("http://aka.ms/dotnet-get-started-desktop");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string jsonString = File.ReadAllText(@"Data\SwimmerTable.json");

            JObject test = JObject.Parse(jsonString);
            JToken t = test.GetValue("data");

            List<Swimmer> swimmers = JsonConvert.DeserializeObject<List<Swimmer>>(t.ToString());

            var hehe = SwimTimes.GetInstance().GetSwimmersTimes(swimmers.ElementAt((swimmers.Count - 2)));
        }
    }
}
