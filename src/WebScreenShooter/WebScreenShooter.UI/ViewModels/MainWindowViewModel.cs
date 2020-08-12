using ReactiveUI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebScreenShooter.Logic;
using WebScreenShooter.Logic.Models;

namespace WebScreenShooter.UI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        string url;
        string sitemapURL;
        string urls;
        string timeout;

        WebScreenShootWorker screenShooter;

        public MainWindowViewModel()
        {
            Add = ReactiveCommand.CreateFromTask(AddHandler);
            GetURLs = ReactiveCommand.CreateFromTask(GetURLsHandler);
            Storage = ReactiveCommand.CreateFromTask(StorageHandler);
            Reset = ReactiveCommand.CreateFromTask(ResetHandler);
            Start = ReactiveCommand.CreateFromTask(StartHandler);
            Exit = ReactiveCommand.CreateFromTask(ExitHandler);

            urlsList = new List<string>();  //urls
            urlHistory = new List<string>();
        }

        public string URL
        {
            get => url;
            set => this.RaiseAndSetIfChanged(ref url, value);
        }
        public string SitemapURL
        {
            get => sitemapURL;
            set => this.RaiseAndSetIfChanged(ref sitemapURL, value);
        }
        public string URLs
        {
            get => urls;
            set => this.RaiseAndSetIfChanged(ref urls, value);
        }

        public string Timeout
        {
            get => timeout;
            set 
            {
                if (int.TryParse(value, out _))
                {
                    this.RaiseAndSetIfChanged(ref timeout, value);
                }
                else
                {
                    Timeout = "0";
                }
            }
        }

        public ReactiveCommand<Unit, Unit> Add { get; }
        public ReactiveCommand<Unit, Unit> GetURLs { get; }
        public ReactiveCommand<Unit, Unit> Storage { get; }
        public ReactiveCommand<Unit, Unit> Reset { get; }
        public ReactiveCommand<Unit, Unit> Start { get; }
        public ReactiveCommand<Unit, Unit> Exit { get; }

        public ObservableCollection<PlatformItem> Platfroms
        {
            get
            {
                return new ObservableCollection<PlatformItem>()
                {
                  new PlatformItem() {Name = "DESKTOP 16:9" },
                  new PlatformItem() {Name = "DESKTOP 4:3" },
                  new PlatformItem() {Name = "MOBILE - HORIZONTAL" },
                  new PlatformItem() {Name = "MOBILE - VERTICAL" },
                  new PlatformItem() {Name = "IPHONE - HORIZONTAL" },
                  new PlatformItem() {Name = "IPHONE - VERTICAL" }
                };
            }
        }


        private List<string> urlsList;
        private List<string> urlHistory;

        async Task AddHandler()
        {
            CheckArea();
            //String urls[] = urlField.getText().split(",");
            //for (String url : urls)
            //{
            //    addURL(url);
            //}
            //urlField.clear();
        }

        async Task GetURLsHandler()
        {
            //checkArea();
            //addSitemap();
        }

        async Task StorageHandler()
        {
            //chooseStorage(directoryChooser);
            //directoryChooser.setInitialDirectory(defaultDir);
        }

        async Task ResetHandler()
        {
            //reset();
        }

        async Task StartHandler()
        {
            CheckArea();
            //timeout = waitField.getText().isEmpty() ? 9999 : Integer.valueOf(waitField.getText());
            //startProgram();
        }

        async Task ExitHandler()
        {
            //endProgram();
        }


        void CheckArea()
        {
            string area = URLs;
            URLs = string.Empty;
            urlsList.Clear();
            string[] urls = area.Split("\n");
            foreach (var url in urls)
            {
                var value = Regex.Replace(url, "\\d*. ", "");
                if (value.Length > 0)
                {
                    AddURL(url);
                }
            }
        }

        public async Task AddURL(string url)
        {
            if (url.Length == 0)
            {
                return;
            }

            if (url.Contains(".xml"))
            {
                SitemapURL = URL;
                URL = string.Empty;
            }
            else
            {
                urlsList.Add(url);
                URLs += urlsList.Count + ". " + url + "\n";
                urlHistory.Add(url);
            }
        }
    }
}
