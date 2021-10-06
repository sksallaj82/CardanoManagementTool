using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PM = CardanoManagementTool.Infrastructure.ProcessManager;

namespace CardanoManagementTool.Infrastructure.Service
{
    public class CardanoNodeDockerService : ICardanoNodeService
    {
        private ICardanoNodeService BaseNodeService { get; set; } = new CardanoNodeService();

        Func<string, bool> CheckVersion = line =>
        {
            string[] list = line.Split(", ");
            return true;
        };

        Func<string, bool> CheckImageExist = line =>
        {
            string[] list = Regex.Replace(line, @"\s+", ",").Split();
            return true;
        };

        Func<string, bool> CreateVolumes = line =>
        {
            //onsole.WriteLine(line);
            return true;
        };

        public List<(Process, Func<string, bool>)> Start()
        {
            List<(Process, Func<string, bool>)> _workers = new();

            Process p;
            //Looking for Docker version 20.10.8, build 3967b7d
            ProcessCommand command = new()
            {
                file = "docker",
                args = "-v"
            };
            p = PM.Start(command);
            _workers.Add((PM.Start(command), CheckVersion));

            //REPOSITORY: inputoutput/cardano-node  (look for this tag)
            //TAG: latest
            //IMAGE ID
            //CREATED
            //SIZE
            command.args = "image ls";
            _workers.Add((PM.Start(command), CheckImageExist));
            //processManager.ReadResult(p, CheckImageExist);

            //You can run these in docker as much as you want, it will not create new ones
            //pc1.args = "volume create cardano-node-data"; //running containers
            //pc1.args = "volume create cardano-node-ipc"; //all containers

            command.args = "volume ls"; //volumes
            _workers.Add((PM.Start(command), CreateVolumes));


            BaseNodeService.Start(); //run any natural process in starting Cardano node

            return _workers;
        }

        public void Stop()
        {
            BaseNodeService.Start();
        }
    }
}
