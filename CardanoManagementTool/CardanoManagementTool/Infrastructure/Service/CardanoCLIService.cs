using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PM = CardanoManagementTool.Infrastructure.ProcessManager;

namespace CardanoManagementTool.Infrastructure.Service
{
    public class CardanoCLIService : IService
    {
        private readonly ProcessCommand command = new() { file = "cardano-cli" };

        public CardanoCLIService() { }

        public List<(Process, Func<string, bool>)> Start()
        {
            List<(Process, Func<string, bool>)> _workers = new();
            //Looking for Docker version 20.10.8, build 3967b7d

            command.args = "-v";
            Process p = PM.Start(command);
            _workers.Add((PM.Start(command),
                line =>
                {
                    return true;
                }
            ));

            return _workers;
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
