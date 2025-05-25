using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BP_GTAV_WpfApp
{
    // Данный класс подсчитывает действия, выполненные с другом
    internal class WithFriendDoing
    {
        public WithFriendDoing() { }

        [JsonProperty("clubDoing")]
        public byte Club { get; set; } = 0;

        [JsonProperty("clubFriendDoing")]
        public byte ClubFriend { get; set; } = 0;


        [JsonProperty("kartingDoing")]
        public bool Karting { get; set; } = false;

        [JsonProperty("kartingFriendDoing")]
        public bool KartingFriend { get; set; } = false;


        [JsonProperty("StreetRaceDoing")]
        public bool StreetRace { get; set; } = false;

        [JsonProperty("StreetRaceFriendDoing")]
        public bool StreetRaceFriend { get; set; } = false;


        [JsonProperty("TrainingComplexDoing")]
        public byte TrainingComplex { get; set; } = 0;

        [JsonProperty("TrainingComplexFriendDoing")]
        public byte TrainingComplexFriend { get; set; } = 0;


        [JsonProperty("ArenaDoing")]
        public bool Arena { get; set; } = false;

        [JsonProperty("ArenaFriendDoing")]
        public bool ArenaFriend { get; set; } = false;

    }
}
