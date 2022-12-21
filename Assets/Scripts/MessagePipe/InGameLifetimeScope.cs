using VContainer;
using VContainer.Unity;
using MessagePipe;
using UnityEngine;

/// <summary>
/// コンテナ
/// </summary>
public class InGameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        MessagePipeOptions options = builder.RegisterMessagePipe();
        
        builder.RegisterMessageBroker<string>(options);
        builder.RegisterMessageBroker<AttackData>(options);

        // Boxプレハブをジェネレーターから動的に生成したい
        // 動的に生成したオブジェクトはInject出来ないがどうにかしたい
        // 
        //builder.
        //builder.RegisterEntryPoint<Generator>(Lifetime.Singleton);
    }
}
