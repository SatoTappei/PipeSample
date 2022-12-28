using VContainer;
using VContainer.Unity;
using MessagePipe;
using UnityEngine;

/// <summary>
/// �R���e�i
/// </summary>
public class InGameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        MessagePipeOptions options = builder.RegisterMessagePipe();
        
        builder.RegisterMessageBroker<string>(options);
        builder.RegisterMessageBroker<AttackData>(options);
    }
}
