using VContainer;
using VContainer.Unity;
using MessagePipe;

/// <summary>
/// ���̂т��p�������ꍇ��MessagePipe�g�p��:�炢�ӂ����[��
/// </summary>
public class DefaultLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        MessagePipeOptions options = builder.RegisterMessagePipe();
        builder.RegisterMessageBroker<int>(options);
    }
}
