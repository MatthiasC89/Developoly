using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Administrator_Interface.Entities
{
    public class Communication
    {

        private string _action;
        private string _data;

        public string Action
        {
            get { return this._action; }
            set { this._action = value; }
        }

        public string Data
        {
            get { return this._data; }
            set { this._data = value; }
        }

        public Communication(string action, string data)
        {
            this.Action = action;
            this.Data = data;
        }
    }
}
