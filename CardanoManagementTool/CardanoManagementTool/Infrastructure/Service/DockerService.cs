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
    public class DockerService : IService
    {
        private IService NodeService { get; set; } = new CardanoNodeDockerService("mainnet");
        private readonly ProcessCommand command = new() { file = "docker" };

        public List<(Process, Func<string, bool>)> Start()
        {
            List<(Process, Func<string, bool>)> _workers = new();

            //Looking for Docker version 20.10.8, build 3967b7d

            command.args = "-v";
            Process p = PM.Start(command);

            _workers.Add((PM.Start(command),
                line =>
                {
                    string[] list = line.Split(", ");
                    return true;
                }
            ));

            //REPOSITORY: inputoutput/cardano-node  (look for this tag)
            //TAG: latest
            //IMAGE ID
            //CREATED
            //SIZE
            command.args = "image ls";
            _workers.Add((PM.Start(command),
                line =>
                {
                    string[] list = Regex.Replace(line, @"\s+", ",").Split();
                    return true;
                }
            ));
            //processManager.ReadResult(p, CheckImageExist);

            //You can run these in docker as much as you want, it will not create new ones
            //pc1.args = "volume create cardano-node-data"; //running containers
            //pc1.args = "volume create cardano-node-ipc"; //all containers

            command.args = "volume ls"; //volumes

            _workers.Add((PM.Start(command),
                line =>
                {
                    //onsole.WriteLine(line);
                    return true;
                }
            ));


            NodeService.Start(); //run any natural process in starting Cardano node

            return _workers;
        }

        public void Stop()
        {
            NodeService.Start();
        }
    }
}
