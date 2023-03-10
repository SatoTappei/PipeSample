using VContainer;
using VContainer.Unity;
using MessagePipe;

/// <summary>
/// ものびを継承した場合のMessagePipe使用例:らいふすこーぷ
/// </summary>
public class DefaultLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        MessagePipeOptions options = builder.RegisterMessagePipe();
        builder.RegisterMessageBroker<int>(options);
    }
}
