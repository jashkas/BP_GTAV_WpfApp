using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP_GTAV_WpfApp
{
    internal class BpData
    {
        [JsonProperty("bp")]
        public int Bp { get; set; } = 0;

        [JsonProperty("date")]
        public string Date { get; set; } = DateTime.Now.ToShortDateString();

        [JsonProperty("bpDoing")]
        public BpDoing BpDoing { get; set; }

        [JsonProperty("bpCounter")]
        public BpCounter BpCounter { get; set; }

        public BpData() 
        {
            this.BpDoing = new BpDoing();
            this.BpCounter = new BpCounter(false, true);
        }
        public BpData(int bp)
        {
            this.Bp = bp;
            this.BpDoing = new BpDoing();
            this.BpCounter = new BpCounter(false, true);
        }
    }
}
