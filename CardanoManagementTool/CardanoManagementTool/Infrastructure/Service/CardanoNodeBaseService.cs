using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardanoManagementTool.Infrastructure.Service
{
    public class CardanoNodeBaseService : ICardanoNodeService
    {

        public CardanoNodeBaseService() { }

        public bool IsDockerFlag { get; set; }
        public List<(Process, Func<string, bool>)> Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
