using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardanoManagementTool.Infrastructure.Service
{
    public interface ICardanoNodeService
    {
        public List<(Process, Func<string, bool>)> Start();
        public void Stop();
    }
}
