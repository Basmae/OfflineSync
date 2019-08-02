using System;
using System.Collections.Generic;
using System.Text;

namespace OfflineSync.Model
{
    public class User
    {
        public string id { get; set; }
        public string UserName { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public string version { get; set; }
        public bool deleted { get; set; }

    }
}
