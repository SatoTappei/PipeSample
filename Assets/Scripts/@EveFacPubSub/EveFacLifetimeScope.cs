using VContainer;
using VContainer.Unity;
using MessagePipe;

/// <summary>
/// �C�x���g�t�@�N�g���[��MessagePipe�g�p��:�炢�ӂ����[��
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
