using VContainer;
using VContainer.Unity;
using MessagePipe;
using UnityEngine;

/// <summary>
/// ƒRƒ“ƒeƒi
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
