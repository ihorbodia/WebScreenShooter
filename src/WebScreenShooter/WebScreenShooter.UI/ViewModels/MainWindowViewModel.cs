﻿using System;
using System.Collections.Generic;
using System.Text;
using WebScreenShooter.Logic.Models;

namespace WebScreenShooter.UI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string URL => "";
        public string SitemapURL => "";
        public string URLs => "";
        public List<PlatformItem> Platfroms
        {
            get
            {
                return new List<PlatformItem>()
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
