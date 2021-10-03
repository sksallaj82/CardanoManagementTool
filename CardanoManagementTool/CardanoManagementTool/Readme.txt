Changing config for node: https://github.com/input-output-hk/cardano-node/blob/master/doc/getting-started/understanding-config-files.md/
minting tokens: https://developers.cardano.org/docs/native-tokens/minting/

Cardano without docker
Currently, the Windows installation guide is still in progress. In the meantime, we recommend using WSL (Windows Subsystem for Linux) to get 
a Linux environment on top of Windows. Once installed, you can use the Linux guide to install and run cardano-node within WSL.

Once docker is loaded

Listening on http://127.0.0.1:12798

[2a5d6cd5:cardano.node.networkMagic:Notice:5] [2021-10-03 08:42:17.63 UTC] NetworkMagic 764824073
[2a5d6cd5:cardano.node.basicInfo.protocol:Notice:5] [2021-10-03 08:42:17.63 UTC] Byron; Shelley
[2a5d6cd5:cardano.node.basicInfo.version:Notice:5] [2021-10-03 08:42:17.63 UTC] 1.30.1
[2a5d6cd5:cardano.node.basicInfo.commit:Notice:5] [2021-10-03 08:42:17.63 UTC] 0fb43f4e3da8b225f4f86557aed90a183981a64f
[2a5d6cd5:cardano.node.basicInfo.nodeStartTime:Notice:5] [2021-10-03 08:42:17.63 UTC] 2021-10-03 08:42:17.636611383 UTC
[2a5d6cd5:cardano.node.basicInfo.systemStartTime:Notice:5] [2021-10-03 08:42:17.63 UTC] 2017-09-23 21:44:51 UTC
[2a5d6cd5:cardano.node.basicInfo.slotLengthByron:Notice:5] [2021-10-03 08:42:17.63 UTC] 20s
[2a5d6cd5:cardano.node.basicInfo.epochLengthByron:Notice:5] [2021-10-03 08:42:17.63 UTC] 21600
[2a5d6cd5:cardano.node.basicInfo.slotLengthShelley:Notice:5] [2021-10-03 08:42:17.63 UTC] 1s
[2a5d6cd5:cardano.node.basicInfo.epochLengthShelley:Notice:5] [2021-10-03 08:42:17.63 UTC] 432000
[2a5d6cd5:cardano.node.basicInfo.slotsPerKESPeriodShelley:Notice:5] [2021-10-03 08:42:17.63 UTC] 129600
[2a5d6cd5:cardano.node.basicInfo.slotLengthAllegra:Notice:5] [2021-10-03 08:42:17.63 UTC] 1s
[2a5d6cd5:cardano.node.basicInfo.epochLengthAllegra:Notice:5] [2021-10-03 08:42:17.63 UTC] 432000
[2a5d6cd5:cardano.node.basicInfo.slotsPerKESPeriodAllegra:Notice:5] [2021-10-03 08:42:17.63 UTC] 129600
[2a5d6cd5:cardano.node.basicInfo.slotLengthMary:Notice:5] [2021-10-03 08:42:17.63 UTC] 1s
[2a5d6cd5:cardano.node.basicInfo.epochLengthMary:Notice:5] [2021-10-03 08:42:17.63 UTC] 432000
[2a5d6cd5:cardano.node.basicInfo.slotsPerKESPeriodMary:Notice:5] [2021-10-03 08:42:17.63 UTC] 129600
[2a5d6cd5:cardano.node.basicInfo.slotLengthAlonzo:Notice:5] [2021-10-03 08:42:17.63 UTC] 1s
[2a5d6cd5:cardano.node.basicInfo.epochLengthAlonzo:Notice:5] [2021-10-03 08:42:17.63 UTC] 432000
[2a5d6cd5:cardano.node.basicInfo.slotsPerKESPeriodAlonzo:Notice:5] [2021-10-03 08:42:17.63 UTC] 129600
[2a5d6cd5:cardano.node.addresses:Notice:5] [2021-10-03 08:42:17.63 UTC] [SocketInfo 0.0.0.0:3001]
[2a5d6cd5:cardano.node.diffusion-mode:Notice:5] [2021-10-03 08:42:17.63 UTC] InitiatorAndResponderDiffusionMode
[2a5d6cd5:cardano.node.dns-producers:Notice:5] [2021-10-03 08:42:17.63 UTC] [DnsSubscriptionTarget {dstDomain = "relays-new.cardano-mainnet.iohk.io", dstPort = 3001, dstValency = 1}]
[2a5d6cd5:cardano.node.ip-producers:Notice:5] [2021-10-03 08:42:17.63 UTC] IPSubscriptionTarget {ispIps = [], ispValency = 0}


get everything after "UTC] "

After we get to 100%

[2a5d6cd5:cardano.node.DiffusionInitializationTracer:Info:94] [2021-10-03 08:42:55.76 UTC] CreatingServerSocket 0.0.0.0:3001
[2a5d6cd5:cardano.node.DiffusionInitializationTracer:Info:94] [2021-10-03 08:42:55.76 UTC] ConfiguringServerSocket 0.0.0.0:3001
[2a5d6cd5:cardano.node.DiffusionInitializationTracer:Info:94] [2021-10-03 08:42:55.76 UTC] ListeningServerSocket 0.0.0.0:3001
[2a5d6cd5:cardano.node.DiffusionInitializationTracer:Info:94] [2021-10-03 08:42:55.76 UTC] ServerSocketUp 0.0.0.0:3001
[2a5d6cd5:cardano.node.DiffusionInitializationTracer:Info:94] [2021-10-03 08:42:55.76 UTC] RunServer 0.0.0.0:3001
[2a5d6cd5:cardano.node.DiffusionInitializationTracer:Info:97] [2021-10-03 08:42:55.76 UTC] CreateSystemdSocketForSnocketPath "/ipc/node.socket"
[2a5d6cd5:cardano.node.DiffusionInitializationTracer:Info:97] [2021-10-03 08:42:55.76 UTC] CreatedLocalSocket "/ipc/node.socket"
[2a5d6cd5:cardano.node.DiffusionInitializationTracer:Info:97] [2021-10-03 08:42:55.76 UTC] ConfiguringLocalSocket "/ipc/node.socket" (FileDescriptor 25)
[2a5d6cd5:cardano.node.DiffusionInitializationTracer:Info:97] [2021-10-03 08:42:55.76 UTC] ListeningLocalSocket "/ipc/node.socket" (FileDescriptor 25)
[2a5d6cd5:cardano.node.DiffusionInitializationTracer:Info:97] [2021-10-03 08:42:55.76 UTC] LocalSocketUp "/ipc/node.socket" (FileDescriptor 25)
[2a5d6cd5:cardano.node.DiffusionInitializationTracer:Info:97] [2021-10-03 08:42:55.76 UTC] RunLocalServer (LocalAddress "/ipc/node.socket")
[2a5d6cd5:cardano.node.ChainDB:Info:76] [2021-10-03 08:42:56.63 UTC] Took ledger snapshot DiskSnapshot {dsNumber = 5493640, dsSuffix = Nothing} at eda0dbaab5391b09f0e073c10d20872379b440278a922538e4e845abe9aa29c8 at slot 5493640

THEN

[2a5d6cd5:cardano.node.DnsSubscription:Notice:108] [2021-10-03 08:42:56.83 UTC] Domain: "relays-new.cardano-mainnet.iohk.io" Connection Attempt Start, destination 18.194.25.1:3001
[2a5d6cd5:cardano.node.DnsSubscription:Notice:109] [2021-10-03 08:42:56.85 UTC] Domain: "relays-new.cardano-mainnet.iohk.io" Connection Attempt Start, destination 18.158.115.215:3001
[2a5d6cd5:cardano.node.DnsSubscription:Notice:110] [2021-10-03 08:42:56.88 UTC] Domain: "relays-new.cardano-mainnet.iohk.io" Connection Attempt Start, destination 13.57.118.58:3001
[2a5d6cd5:cardano.node.DnsSubscription:Notice:111] [2021-10-03 08:42:56.90 UTC] Domain: "relays-new.cardano-mainnet.iohk.io" Connection Attempt Start, destination 3.22.52.164:3001
[2a5d6cd5:cardano.node.DnsSubscription:Notice:112] [2021-10-03 08:42:56.93 UTC] Domain: "relays-new.cardano-mainnet.iohk.io" Connection Attempt Start, destination 54.179.126.222:3001
[2a5d6cd5:cardano.node.DnsSubscription:Notice:111] [2021-10-03 08:42:56.94 UTC] Domain: "relays-new.cardano-mainnet.iohk.io" Connection Attempt End, destination 3.22.52.164:3001 outcome: ConnectSuccessLast
[2a5d6cd5:cardano.node.ErrorPolicy:Notice:90] [2021-10-03 08:42:56.94 UTC] IP 18.194.25.1:3001 ErrorPolicySuspendConsumer (Just (ConnectionExceptionTrace (SubscriberError {seType = SubscriberParallelConnectionCancelled, seMessage = "Parallel connection cancelled", seStack = []}))) 1s
[2a5d6cd5:cardano.node.ErrorPolicy:Notice:90] [2021-10-03 08:42:56.94 UTC] IP 18.158.115.215:3001 ErrorPolicySuspendConsumer (Just (ConnectionExceptionTrace (SubscriberError {seType = SubscriberParallelConnectionCancelled, seMessage = "Parallel connection cancelled", seStack = []}))) 1s
[2a5d6cd5:cardano.node.ErrorPolicy:Notice:90] [2021-10-03 08:42:56.94 UTC] IP 13.57.118.58:3001 ErrorPolicySuspendConsumer (Just (ConnectionExceptionTrace (SubscriberError {seType = SubscriberParallelConnectionCancelled, seMessage = "Parallel connection cancelled", seStack = []}))) 1s
[2a5d6cd5:cardano.node.ErrorPolicy:Notice:90] [2021-10-03 08:42:56.94 UTC] IP 54.179.126.222:3001 ErrorPolicySuspendConsumer (Just (ConnectionExceptionTrace (SubscriberError {seType = SubscriberParallelConnectionCancelled, seMessage = "Parallel connection cancelled", seStack = []}))) 1s

THEN we get the final piece

[2a5d6cd5:cardano.node.ChainDB:Notice:72] [2021-10-03 08:42:57.22 UTC] Chain extended, new tip: e5924d190920352d22657e34d7bdf800eac0f70711718d8ff81de8c99e2d0da9 at slot 5536860
[2a5d6cd5:cardano.node.ChainDB:Notice:72] [2021-10-03 08:42:58.47 UTC] Chain extended, new tip: e44ef2e20ae59ca3781a18b496c50ff135f483b8c2fc88c2ae10c45a98e526e1 at slot 5548700
[2a5d6cd5:cardano.node.ChainDB:Notice:72] [2021-10-03 08:42:59.72 UTC] Chain extended, new tip: 91d22ac07f8b53f37dd92d213c452c734a835970d4295c0907cd82134b450cec at slot 5559480
[2a5d6cd5:cardano.node.ChainDB:Notice:72] [2021-10-03 08:43:00.97 UTC] Chain extended, new tip: 045bc4a3ba7ade898b7538248a60ed6a4715094548e7db2e4dd0bc507ee6314f at slot 5572060

on going