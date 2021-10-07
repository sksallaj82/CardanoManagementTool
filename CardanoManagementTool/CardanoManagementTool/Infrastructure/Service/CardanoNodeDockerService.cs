﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PM = CardanoManagementTool.Infrastructure.ProcessManager;

namespace CardanoManagementTool.Infrastructure.Service
{
    public class CardanoNodeDockerService : IService
    {
        private readonly ProcessCommand command = new() { file = "docker" };
        private readonly string network;

        public CardanoNodeDockerService(string network) 
        {
            this.network = network;
        }

        public List<(Process, Func<string, bool>)> Start()
        {
            List<(Process, Func<string, bool>)> _workers = new();
            //Looking for Docker version 20.10.8, build 3967b7d
 
            //Todo: Need to tell if docker is running or not
            //Todo: Need to tell when we are finished with the stream
            //Todo: Add to process manager that when I shut the last remaining
            //  process that there is no more left (it hits an exception)

            command.args = string.Format("run -e NETWORK={0} -v cardano-node-ipc:/ipc -v cardano-node-data:/data inputoutput/cardano-node", network);
            command.name = CommandType.StartCardanoNode;
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
