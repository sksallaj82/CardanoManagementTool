using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardanoManagementTool.Infrastructure
{
    public enum CommandType
    {
        None,
        StartCardanoNode,
        StopCardanoNode
    }

    /// <summary>
    /// Process Manager has an internal mechanism that will check and make sure only one process
    /// of a time can run at any given moment
    /// </summary>
    public class ProcessManager
    {
        public List<(int Id, CommandType CommandType, Process Process)> Workers { get; set; } = new();

        Func<CommandType, bool> StartOnlyOneCardanoNode = type => type == CommandType.StartCardanoNode;

        public Process Start(ProcessCommand command)
        {
            Process process = new();
            if (ValidateRules(command.name))
            {
                ProcessStartInfo processStartInfo = new(command.file, command.args)
                {
                    CreateNoWindow = true,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    StandardErrorEncoding = Encoding.UTF8,
                    StandardOutputEncoding = Encoding.UTF8,
                    UseShellExecute = false
                };
                process = Process.Start(processStartInfo);
                Workers.Add((process.Id, command.name, process));
            }
            return process;
        }

        public Process FindProcessById(int id)
        {
            return Workers.Find(x => x.Id == id).Process;
        }

        public Process FindProcessByCommandype(CommandType type)
        {
            return Workers.Find(x => x.CommandType == type).Process;
        }

        public (int,CommandType,Process) FindWorkerByProcessorId(int id)
        {
            return Workers.Find(x => x.Id == id);
        }

        public (int, CommandType, Process) FindWorkerByProcessorCommandype(CommandType type)
        {
            return Workers.Find(x => x.CommandType == type);
        }

        /// <summary>
        /// If a process is running, it will be stopped and removed
        /// </summary>
        /// <param name="p"></param>
        /// <param name="name"></param>
        public void Stop(Process p)
        {
            _ = Workers.Remove(FindWorkerByProcessorId(p.Id));
            p.Kill();
            p.WaitForExit();
            p.Dispose();
        }

        /// <summary>
        /// Checks rules on what is allowed. If anything comes in and breaks the rules, don't execute the process.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private bool ValidateRules(CommandType type)
        {
            var retVal = true;
            if (StartOnlyOneCardanoNode(type))
            {
                retVal = retVal && Workers.Where(x => x.CommandType == type).Count() != 1;
            }
            return retVal;
        }

        /// <summary>
        /// Checks if a process is running and if not, clean
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool CheckRunning(Process p)
        {
            if (p == null)
            {
                throw new ArgumentNullException("process");
            }

            try
            {
                _ = Process.GetProcessById(p.Id);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException or InvalidOperationException)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Stops and removes any running processes
        /// </summary>
        public void Shutdown()
        {
            foreach ((int Id, CommandType CommandType, Process Process) worker in Workers)
            {
                Stop(worker.Process);
            }
        }
    }
}
