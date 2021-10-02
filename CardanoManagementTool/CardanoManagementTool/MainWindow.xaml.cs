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
            this.InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            myButton.Content = "Clicked";
            ProcessCommand pc1 = new()
            {
                file = "ping",
                args = "google.com",
                name = ProcessType.StartCardanoNode
            };
            Process p = RunNew(pc1);
            p.OutputResult(myTerminalLog, myScroller);

            ProcessCommand pc2 = new()
            {
                file = "bash",
                args = @"-c ""cd ~/ ; ls"" ",
                name = ProcessType.StartCardanoNode
            };
            Process p1 = RunNew(pc2);
            p1.OutputResult(myTerminalLog, myScroller);
            

            //reader = StartPR.StandardOutput;
            //var test1 = reader.ReadToEnd();
        }

        private Process RunNew(ProcessCommand command)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo(command.file, command.args)
            {
                CreateNoWindow = true,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                StandardErrorEncoding = Encoding.UTF8,
                StandardOutputEncoding = Encoding.UTF8,
                UseShellExecute = false
            };

            Process process = Process.Start(processStartInfo);
            processManager.Add(process, command.name);

            return process;
        }
    }

    public static class ProcessExtensions
    {
        public async static void OutputResult(this Process process, TextBlock uiElement, ScrollViewer scroller)
        {
            string line;
            await Task.Run(() => {
                _ = uiElement.DispatcherQueue.TryEnqueue(async () =>
                  {
                      using (StreamReader reader = process.StandardOutput)
                      {
                          while ((line = await reader.ReadLineAsync()) != null)
                          {
                              uiElement.Text += line + Environment.NewLine;
                              await scroller.ScrollToBottom();
                          }
                      };
                  });
            });
        }

        public static List<(int, Process, string)> AddToProcessManager(this Process process, List<(int,Process,string)> list)
        {
            list.Add((process.Id, process, process.ProcessName));
            return list;
        }

        public async static Task ScrollToBottom(this ScrollViewer scroller)
        {
            scroller.ScrollToVerticalOffset(scroller.ScrollableHeight);
            await Task.Delay(1);
        }
    }
}
