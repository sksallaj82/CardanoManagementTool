using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CardanoManagementTool
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            myButton.Content = "Clicked";
            ProcessStartInfo processStartInfo = new("ping", "google.com")
            {
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            ProcessStartInfo PR = processStartInfo;
            Process StartPR = new()
            {
                StartInfo = PR
            };
            StartPR.Start();

            string line = "";
            var result = "";
            using (StreamReader reader = StartPR.StandardOutput)
            {
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
               // Console.WriteLine("First line contains: " + result);
            }

            //StreamReader reader = StartPR.StandardOutput;
            //var test = reader.ReadToEnd();
            ProcessStartInfo PR1 = new("bash", @"-c ""cd ~/ ; ls"" ")
            {
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                StandardOutputEncoding = Encoding.UTF8,
                StandardErrorEncoding = Encoding.UTF8
            };
            Process StartPR1 = new()
            {
                StartInfo = PR1
            };
            StartPR1.Start();

            //StartPR1.StandardInput.WriteLine("bash");
            //StartPR1.StandardInput.WriteLine("ls");
            //System.Threading.Thread.Sleep(500);
            //StartPR1.StandardInput.Flush();
            //StartPR1.StandardInput.Close();
            //StartPR1.WaitForExit(5000);


            using (StreamReader reader = StartPR1.StandardOutput)
            {
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
                // Console.WriteLine("First line contains: " + result);
            }

            StartPR1.WaitForExit();
  
            //reader = StartPR.StandardOutput;
            //var test1 = reader.ReadToEnd();
        }

        private static Process RunNew(string file, string args, string workingDir)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo(file, args)
            {
                WindowStyle = ProcessWindowStyle.Minimized,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                WorkingDirectory = workingDir,
                StandardOutputEncoding = Encoding.UTF8,
                StandardErrorEncoding = Encoding.UTF8,
            };

            Process process = Process.Start(processStartInfo);
            return process;
        }
    }
}
