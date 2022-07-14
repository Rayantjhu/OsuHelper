using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ookii.Dialogs.Wpf;
using OsuHelper.Properties;
using OsuHelper.Dialogs;
using System.Windows;

namespace OsuHelper.Backend
{
    internal class OsuDirectory
    {
        UpdatePathDialogs Dialogs = new UpdatePathDialogs();

        /// <summary>
        /// Checks if the given path is most probably an osu! folder
        /// </summary>
        /// <param name="path"></param>
        /// <returns>true, if path consists of a Date, Replays, Skins, Songs and Screenshots folder and an osu!.exe file</returns>
        public bool IsOsuPath(string path)
        {
            if (path == null || path == "")
                return false;

            if (!Directory.Exists(path))
                return false;

            // Gets the 6 directories which are in the osu! folder
            string[] directories = Directory.GetDirectories(path)
                                     .Where(dir => dir.EndsWith("Data") || dir.EndsWith("Replays") || dir.EndsWith("Skins") || dir.EndsWith("Songs") || dir.EndsWith("Screenshots"))
                                     .ToArray();
            
            // If not all six directories exist, it's most likely not the osu! folder
            if (directories.Length < 5)
                return false;

            // if the osu!.exe file is not in the root directory, it's most likely not the osu! folder
            if (Directory.GetFiles(path, "osu!.exe") == null)
                return false;

            return true;
        }

        /// <summary>
        /// Checks whether the current Osu Path is still valid and the folder exists. If it's not valid, it will ask the user to select a new path
        /// </summary>
        /// <param name="app"></param>
        public void CheckPathAndSelectNew(Application app)
        {
            string currentOsuPath = Settings.Default.OsuPath;

            if (!Directory.Exists(currentOsuPath) || !IsOsuPath(currentOsuPath))
                NewPathAfterError(app);
        }

        /// <summary>
        /// If it's the first launch of the application, get the osu! folder path from the Appdata/Local folder, otherwise it doesn't do anything.
        /// </summary>
        public void FirstLaunchCheck()
        {
            // Checks if it is the first launch
            if (Settings.Default.FirstLaunch is true)
            {
                // Gets the path from the Appdata/Local folder
                string osuPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "osu!");

                // If the path isn't valid, a dialog will be shown and user needs to select the osu! folder
                if (!IsOsuPath(osuPath))
                {
                    Dialogs.FirstLaunchPathErrorDialog();

                    // If changing the path wasn't successful, we want to abort the application
                    if (!SelectAndSetNewOsuPath())
                    {
                        Environment.Exit(0);
                    }
                    return;
                }

                Settings.Default.OsuPath = osuPath; 
                Settings.Default.FirstLaunch = false;
                Settings.Default.Save();
            }
        }

        /// <summary>
        /// Handles selecting a new osu! path with the FolderBrowserDialog and saves it if the path is most likely an osu! folder
        /// </summary>
        /// <returns>true, if the selecting and saving of the path went successful, else false</returns>
        public bool SelectAndSetNewOsuPath()
        {
            // Creates the folder browser to select a new path
            VistaFolderBrowserDialog folderBrowserDialog = new VistaFolderBrowserDialog();


            while (true)
            {
                folderBrowserDialog.ShowDialog();

                // No path is selected
                if (string.IsNullOrEmpty(folderBrowserDialog.SelectedPath))
                {

                    // Shows invalid path dialog
                    if (Dialogs.ShowInvalidInputDialog())
                        continue;
                    return false;
                }
                else
                {
                    // Checks if path is most possibly the osu! folder
                    if (IsOsuPath(folderBrowserDialog.SelectedPath))
                    {  
                        // Saves the new path
                        Settings.Default.OsuPath = folderBrowserDialog.SelectedPath;
                        Settings.Default.Save();

                        // Shows success dialog
                        Dialogs.ShowPathUpdateSuccessDialog();
                        return true;
                    }
                    else
                    {
                        // Shows invalid path dialog
                        if (Dialogs.ShowInvalidInputDialog())
                            continue;
                        return false;
                    }
                }
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public void NewPathAfterError(Application app)
        {
            // The user wants to select a new path
            if (Dialogs.ShowPathErrorDialog())
                SelectAndSetNewOsuPath();
            else
                app.Shutdown();
        }
    }
}
