using CardanoManagementTool.Infrastructure;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

//https://stackoverflow.com/questions/56976636/how-to-update-textblock-in-real-time

namespace CardanoManagementTool
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        ProcessManager processManager = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        Func<string, bool> CheckDockerVersion = line =>
        {
            string[] list = line.Split(", ");
            return true;
        };

        Func<string, bool> CheckImageExist = line =>
        {
            //onsole.WriteLine(line);
            string[] list = Regex.Replace(line, @"\s+", ",").Split();
            return true;
        };

        Func<string, bool> CreateVolumes = line =>
        {
            //onsole.WriteLine(line);
            return true;
        };


        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            myButton.Content = "Clicked";
            //ProcessCommand pc1 = new()
            //{
            //    file = "ping",
            //    args = "google.com",
            //    name = CommandType.StartCardanoNode
            //};

            Process p;

            //Looking for Docker version 20.10.8, build 3967b7d
            ProcessCommand command = new()
            {
                file = "docker",
                args = "-v"
            };

            p = processManager.Start(command);
            //processManager.OutputResult(p, myTerminalLog, myScroller, CheckDockerVersion);
            processManager.ReadResult(p, CheckDockerVersion);

            //REPOSITORY: inputoutput/cardano-node  (look for this tag)
            //TAG: latest
            //IMAGE ID
            //CREATED
            //SIZE
            command.args = "image ls";
            p = processManager.Start(command);
            //processManager.OutputResult(p, myTerminalLog, myScroller, CheckImageExist);
            processManager.ReadResult(p, CheckImageExist);

            //You can run these in docker as much as you want, it will not create new ones
            //pc1.args = "volume create cardano-node-data"; //running containers
            //pc1.args = "volume create cardano-node-ipc"; //all containers


            //pc1.args = "volume ls"; //volumes

            //ancestor=inputoutput/cardano-node:latest checks image with tag latest
            //ancestor=inputoutput/cardano-node checks for image regarless of tag
            //loop through containers "container ls --filter ancestor=inputoutput/cardano-node" - for stopping running
            //loop "container ls --filter network=mainnet"
            //pc1.args = "stop"; //gracefully stops container, will kill after 10 seconds

            //loop through containers "container ls -a --filter ancestor=inputoutput/cardano-node" - for all containers
            //pc1.args = "rm";

            //always get latest container name (regardless of status)
            //its under NAME  -- last column
            //pc1.args = "container ls --latest";

            //make mainnet a variable
            //running a cardano node - this gets opened into a container
            //Notes
            //"block relay progress (%) = X.XX" shows %
            //GO look at read me to see info we gather
            //pc1.args = "run -e NETWORK=mainnet -v cardano-node-ipc:/ipc -v cardano-node-data:/data inputoutput/cardano-node";


            //CLI - for now, make it free form with access to the directory in the the container

            //ProcessCommand pc2 = new()
            //{
            //    file = "bash",
            //    args = @"-c ""cd ~/ ; ls"" ",
            //    name = ProcessType.StartCardanoNode
            //};
            //Process p1 = processManager.Start(pc2);
            //p1.OutputResult(myTerminalLog, myScroller);



        }
    }

    public static class ProcessExtensions
    {
        public async static void ReadResult(this ProcessManager pm,
            Process process,
            Func<string, bool> callBack)
        {
            string line;
            if (ProcessManager.CheckRunning(process))
            {
                await Task.Run(() =>
                {
                    using (StreamReader reader = process.StandardOutput)
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            callBack(line);
                        }
                        if (reader.EndOfStream)
                        {
                            pm.Stop(pm.FindProcessById(process.Id));
                        }
                    };
                });
            }
        }


        public async static void OutputResult(this ProcessManager pm,
            Process process,
            TextBlock uiElement,
            ScrollViewer scroller,
            Func<string, bool> callBack)
        {
            string line;
            if (ProcessManager.CheckRunning(process))
            {
                await Task.Run(() =>
                {
                    _ = uiElement.DispatcherQueue.TryEnqueue(async () =>
                      {
                          using (StreamReader reader = process.StandardOutput)
                          {
                              while ((line = await reader.ReadLineAsync()) != null)
                              {
                                  callBack(line);
                                  uiElement.Text += line + Environment.NewLine;
                                  await scroller.ScrollToBottom();
                              }
                              if (reader.EndOfStream)
                              {
                                  pm.Stop(pm.FindProcessById(process.Id));
                              }
                          };
                      });
                });
            }
        }

        public async static Task ScrollToBottom(this ScrollViewer scroller)
        {
            scroller.ScrollToVerticalOffset(scroller.ScrollableHeight);
            await Task.Delay(1);
        }
    }
}
