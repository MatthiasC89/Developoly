using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Controls;

namespace Administrator_Interface.Entities
{
    public class CommGamePArameter
    {
        private Dictionary<string, Page> pages;
        private Object service;

        public Dictionary<string, Page> Pages { get => pages; set => pages = value; }
        public Object Services { get => service; set => service = value; }

        public CommGamePArameter(Dictionary<string, Page> page, Object serv)
        {
            Pages = page;
            Services = serv;
        }
    }
}
