using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
            System.Diagnostics.ProcessStartInfo PR = new System.Diagnostics.ProcessStartInfo("ping","google.com");
            PR.RedirectStandardInput = true;
            PR.RedirectStandardOutput = true;
            PR.UseShellExecute = false;
            PR.CreateNoWindow = true;
            System.Diagnostics.Process StartPR = new System.Diagnostics.Process();
            StartPR.StartInfo = PR;
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
            System.Diagnostics.ProcessStartInfo PR1 = new System.Diagnostics.ProcessStartInfo("bash", "ls");
            PR.RedirectStandardInput = true;
            PR.RedirectStandardOutput = true;
            PR.UseShellExecute = false;
            PR.CreateNoWindow = true;
            System.Diagnostics.Process StartPR1 = new System.Diagnostics.Process();
            StartPR.StartInfo = PR;
            StartPR.Start();


            StartPR.WaitForExit();
            StartPR.StandardInput.Write("ipconfig");
            StartPR.StandardInput.Flush();
            StartPR.StandardInput.Close();
            //reader = StartPR.StandardOutput;
            //var test1 = reader.ReadToEnd();
        }
    }
}
