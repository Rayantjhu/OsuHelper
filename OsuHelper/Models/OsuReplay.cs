using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OsuParsers.Replays;
using OsuParsers.Decoders;
using OsuParsers.Enums;

namespace OsuHelper.Models
{
    public class OsuReplay
    {
        public int Id { get; set; }
        public string? Filename { get; set; }
        public Ruleset Ruleset { get; set; }
        public int OsuVersion { get; set; }
        public string BeatmapMD5Hash { get; set; }
        public string PlayerName { get; set; }
        public string ReplayMD5Hash { get; set; }
        public ushort Count300 { get; set; }
        public ushort Count100 { get; set; }
        public ushort Count50 { get; set; }
        public ushort CountGeki { get; set; }
        public ushort CountKatu { get; set; }
        public ushort CountMiss { get; set; }
        public int ReplayScore { get; set; }
        public ushort Combo { get; set; }
        public bool PerfectCombo { get; set; }
        public Mods Mods { get; set; }
        public DateTime ReplayTimestamp { get; set; }
        public int ReplayLength { get; set; }
        public int Seed { get; set; }
        public long OnlineId { get; set; }

        public OsuReplay(string filename)
        {
            Replay replay = ReplayDecoder.Decode(filename);

            Filename = filename;
            Ruleset = replay.Ruleset;
            OsuVersion = replay.OsuVersion;
            BeatmapMD5Hash = replay.BeatmapMD5Hash;
            PlayerName = replay.PlayerName;
            ReplayMD5Hash = replay.ReplayMD5Hash;
            Count300 = replay.Count300;
            Count100 = replay.Count100;
            Count50 = replay.Count50;
            CountGeki = replay.CountGeki;
            CountKatu = replay.CountKatu;
            CountMiss = replay.CountMiss;
            ReplayScore = replay.ReplayScore;
            Combo = replay.Combo;
            PerfectCombo = replay.PerfectCombo;
            Mods = replay.Mods;
            ReplayTimestamp = replay.ReplayTimestamp;
            ReplayLength = replay.ReplayLength;
            Seed = replay.Seed;
            OnlineId = replay.OnlineId;
        }

        /// <summary>
        /// If the filename is the same, they are considered the same replay
        /// </summary>
        /// <param name="replay1"></param>
        /// <param name="replay2"></param>
        /// <returns></returns>
        public static bool operator ==(OsuReplay replay1, OsuReplay replay2)
        {
            return replay1.ReplayMD5Hash == replay2.ReplayMD5Hash;
        }

        public static bool operator !=(OsuReplay replay1, OsuReplay replay2)
        {
            return !(replay1 == replay2);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || ! this.GetType().Equals(obj.GetType()))
                return false;

            return this == (obj as OsuReplay);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
      
    }
}
