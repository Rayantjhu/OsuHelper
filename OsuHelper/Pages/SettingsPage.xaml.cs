using System.ComponentModel;
using System.Windows.Controls;
using System.Windows;
using OsuHelper.Backend;
using System.Collections.Generic;
using OsuHelper.Models;

namespace OsuHelper.Pages
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        private BackgroundWorker BackgroundWorker = new BackgroundWorker();
        private int ReplaysCount { get; set; }

        public SettingsPage()
        {
            InitializeComponent();

            // Setting up background worker
            BackgroundWorker.WorkerReportsProgress = true;
            BackgroundWorker.WorkerSupportsCancellation = true;
            BackgroundWorker.DoWork += new DoWorkEventHandler(DoWork);
            BackgroundWorker.ProgressChanged += new ProgressChangedEventHandler(ProgressChanged);
        }


        void ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = (double)(e.ProgressPercentage + 1) * 100 / ReplaysCount;
        }

        void DoWork(object? sender, DoWorkEventArgs e)
        {
            BackgroundWorker? _worker = sender as BackgroundWorker;
            Replays replaysMethods = new Replays();

            // Creates database context
            DatabaseContext dbContext = new DatabaseContext();

            // Gets the replays and sets the amount of replays
            List<string> replays = replaysMethods.GetReplayFiles();
            ReplaysCount = replays.Count;


            if (_worker != null)
            {
                for (int i = 0; i < ReplaysCount; i++)
                {
                    // Cancel button has been pressed
                    if (_worker.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }

                    // Add replay
                    replaysMethods.AddReplay(replays[i], dbContext);

                    // Reporting progress made
                    _worker.ReportProgress(i);
                }
                dbContext.SaveChanges();
            }
        }

        private void SynchronizeReplays(object sender, RoutedEventArgs e)
        {
            // If the worker isn't yet working
            if (!BackgroundWorker.IsBusy)
                BackgroundWorker.RunWorkerAsync();
            e.Handled = true;
        }
    }
}
