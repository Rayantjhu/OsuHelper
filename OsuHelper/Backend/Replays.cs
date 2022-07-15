using System.IO;
using System.Collections.Generic;
using System.Linq;
using OsuHelper.Models;
using System.ComponentModel;

namespace OsuHelper.Backend
{
    public class Replays
    {
        /// <summary>
        /// Gets all the .osr files from the Data/r and Replays folders from the osu! folder, removes duplicates and returns the list of all the files
        /// </summary>
        /// <returns>A list of strings that are filenames</returns>
        public List<string> GetReplayFiles()
        {
            // Paths to the replay folders
            string replaysFolder = Path.Combine(Properties.Settings.Default.OsuPath.ToString(), "Replays");
            string rawReplaysFolder = Path.Combine(Properties.Settings.Default.OsuPath.ToString(), "Data", "r");

            // Creates a list with all the replay files
            List<string> replayFiles = Directory.GetFiles(replaysFolder).ToList();
            replayFiles.AddRange(Directory.GetFiles(rawReplaysFolder, "*.osr").Except(replayFiles));

            // Deletes all duplicates
            return replayFiles.Distinct().ToList();
        }

        public void AddReplay(string filename, DatabaseContext dbContext)
        {
            // Create the OsuReplay object from the filename
            OsuReplay osuReplay = new OsuReplay(filename);

            // Checks if database already contains the replay, only adds if it doesn't exist
            if (!dbContext.Replays.Any(r => r == osuReplay))
                dbContext.Replays.Add(osuReplay);
        }
    }
}
