using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaRest.Models
{
    public class Pacote
    {
        public string create { get; set; }
        public string insert { get; set; }
        public List<List<string>> dados  { get; set; }
    }
}