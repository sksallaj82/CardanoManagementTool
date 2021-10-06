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
    public sealed class CardanoNodeContainerWrapper
    {
        public ICardanoNodeService ICardanoNodeService { get; private set; }

        public CardanoNodeContainerWrapper (bool isDocker)
        {
            ICardanoNodeService = isDocker ? new CardanoNodeDockerService() : new CardanoNodeBaseService();
        }
    }

    public sealed class CardanoNodeContainer : ICardanoNodeService
    {
        private readonly ICardanoNodeService that;

        public CardanoNodeContainer(ICardanoNodeService that)
        {
            this.that = that;
        }

        List<(Process, Func<string, bool>)> ICardanoNodeService.Start() => Instance.Start();
        void ICardanoNodeService.Stop() => this.Instance.Stop();

        private ICardanoNodeService Instance => that;
    }
}
