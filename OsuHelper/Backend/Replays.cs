using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using OsuHelper.Models;
using Ookii.Dialogs.Wpf;

namespace OsuHelper.Backend
{
    public class Replays
    {
        /// <summary>
        /// Adds all the replay files located inside the osu! folder into the database
        /// </summary>
        public void SyncReplays()
        {
            DatabaseContext databaseContext = new DatabaseContext();

            // Paths to the replay folders
            string replaysFolder = Path.Combine(Properties.Settings.Default.OsuPath.ToString(), "Replays");
            string rawReplaysFolder = Path.Combine(Properties.Settings.Default.OsuPath.ToString(), "Data", "r");

            // Creates a list with all the replay files
            List<string> replayFiles = Directory.GetFiles(replaysFolder).ToList();
            replayFiles.AddRange(Directory.GetFiles(rawReplaysFolder, "*.osr").Except(replayFiles));

            // Deletes all duplicates
            replayFiles = replayFiles.Distinct().ToList();

            ProgressDialog progressDialog = new ProgressDialog()
            {
                WindowTitle = "Synchronizing replays"
            };

            // Parses the replay in the replayFiles and adds it to the database if the it doesn't exist yet
            foreach (string replay in replayFiles)
            {
                OsuReplay osuReplay = new OsuReplay(replay);
                if (!databaseContext.Replays.Any(r => r.BeatmapMD5Hash == osuReplay.BeatmapMD5Hash))
                    databaseContext.Replays.Add(osuReplay);
            }

            databaseContext.SaveChanges();
        }
    }
}
