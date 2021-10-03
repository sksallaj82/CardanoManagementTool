using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardanoManagementTool.Infrastructure
{
    public class ProcessCommand
    {
        public string file { get; set; }
        public string args { get; set; }
        public CommandType name { get; set; }
    }
}
