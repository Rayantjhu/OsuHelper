using Ookii.Dialogs.Wpf;
using OsuHelper.Dialogs.Buttons;

namespace OsuHelper.Dialogs
{
    internal class UpdatePathDialogs
    {
        /// <summary>
        /// Shows the dialog that shows that updating the osu! path was successful
        /// </summary>
        public void ShowPathUpdateSuccessDialog()
        {
            // The task dialog
            TaskDialog taskDialog = new TaskDialog()
            {
                WindowTitle = "Changed path for osu!",
                MainIcon = TaskDialogIcon.Information,
                Content = "The path has been updated successfully."
            };

            // Add Ok button
            taskDialog.Buttons.Add(new OkButton());

            // Showing the dialog
            taskDialog.ShowDialog();
        }

        /// <summary>
        /// Shows the dialog which shows that the input for changing the osu! path is invalid
        /// </summary>
        /// <returns>true, if the user wants to retry the operation, otherwise false</returns>
        public bool ShowInvalidInputDialog()
        {
            // The dialog
            TaskDialog taskDialog = new TaskDialog()
            {
                WindowTitle = "Invalid path",
                MainIcon = TaskDialogIcon.Warning,
                Content = "The chosen path isn't a osu! folder.\n" +
                "Please make sure you select the correct osu! folder.\n\n" +
                "Click \"Select\" to retry or \"Cancel\" to abort."
            };

            // Add Select and Cancel buttons
            taskDialog.Buttons.Add(new SelectButton());
            taskDialog.Buttons.Add(new CancelButton());

            var test = taskDialog.ShowDialog();
            
            // Shows the dialog and returns whether the user wants to retry
            return test.ButtonType == ButtonType.Custom;
        }
        
        /// <summary>
        /// Shows the dialog which shows that the path is not found anymore
        /// </summary>
        /// <returns>true, if the user is going to select a new path, else false</returns>
        public bool ShowPathErrorDialog()
        {
            TaskDialog taskDialog = new TaskDialog()
            {
                WindowTitle = "Path Error",
                Content = "The path is either not found or it is not the correct path.\n" +
                "Please select the osu! path and make sure it contains the osu!.exe file.\n\n" +
                "Click \"Select\" to select the osu! folder, or \"Cancel\" to abort.",
                MainIcon = TaskDialogIcon.Error,
            };

            // Add Select and Cancel buttons
            taskDialog.Buttons.Add(new SelectButton());
            taskDialog.Buttons.Add(new CancelButton());

            // Shows the dialog and returns whether the user is going to select a new folder
            return taskDialog.ShowDialog().ButtonType == ButtonType.Custom;
        }

        /// <summary>
        /// Shows the dialog that shows that after the first launch, the osu! folder, that was tried to get from the Appdata/Local folder, doesn't seem to exist.
        /// </summary>
        public void FirstLaunchPathErrorDialog()
        {
            TaskDialog taskDialog = new TaskDialog()
            {
                WindowTitle = "Path Error",
                Content = "We tried to get the path from osu! from the Appdata/Local folder, " +
                "but it seems the osu! folder doesn't exist inside that folder.\n" +
                "Please select the osu! folder.",
                MainIcon = TaskDialogIcon.Warning
            };

            taskDialog.Buttons.Add(new OkButton());

            taskDialog.ShowDialog();
        }
    }
}
