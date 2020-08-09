using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;
using WebScreenShooter.Logic.Models;

namespace WebScreenShooter.UI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        string url;
        string sitemapURL;
        string urls;

        public MainWindowViewModel()
        {
            Add = ReactiveCommand.Create(() => { });
            GetURL = ReactiveCommand.Create(() => { });
            Storage = ReactiveCommand.Create(() => { });
            Reset = ReactiveCommand.Create(() => { });
            Start = ReactiveCommand.Create(() => { });
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

        public ReactiveCommand<Unit, Unit> Add { get; }
        public ReactiveCommand<Unit, Unit> GetURL { get; }
        public ReactiveCommand<Unit, Unit> Storage { get; }
        public ReactiveCommand<Unit, Unit> Reset { get; }
        public ReactiveCommand<Unit, Unit> Start { get; }

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


    }
}
