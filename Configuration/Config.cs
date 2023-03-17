﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreDemo.Configuration
{
    public class Config
    {
        public string BaseEnviroment { get; set; }
        public Dictionary<string, PetStoreEnviroment> Enviroments { get; set; }
    }

    public class PetStoreEnviroment
    {
        public string Url { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Dictionary<string, string> Endpoints { get; set; }
    }
}
