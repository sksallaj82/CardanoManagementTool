using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// This contains and holds whatever implements ICardanoNodeService
/// </summary>
namespace CardanoManagementTool.Infrastructure.Service
{
    public sealed class CardanoNodeContainerFactory
    {
        public IService IService { get; private set; }

        public CardanoNodeContainerFactory (bool isDocker)
        {
            IService = isDocker ? new DockerService() : new CardanoNodeWSLService();
        }
    }

    public sealed class CardanoNodeProxy : IService
    {
        private readonly IService that;

        public CardanoNodeProxy(IService that)
        {
            this.that = that;
        }

        List<(Process, Func<string, bool>)> IService.Start() => Instance.Start();
        void IService.Stop() => this.Instance.Stop();

        private IService Instance => that;
    }
}
