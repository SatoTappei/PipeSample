using VContainer;
using VContainer.Unity;
using MessagePipe;

/// <summary>
/// イベントファクトリーのMessagePipe使用例:らいふすこーぷ
/// </summary>
public class EveFacLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        MessagePipeOptions options = builder.RegisterMessagePipe();
        builder.RegisterMessageBroker<int>(options);
        builder.RegisterEntryPoint<EveFacPubSub>(Lifetime.Singleton);
    }
}
