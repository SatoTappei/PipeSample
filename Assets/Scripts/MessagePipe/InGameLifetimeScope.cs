using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MessagePipe;
using VContainer;
using VContainer.Unity;

/// <summary>
/// コンテナ
/// </summary>
public class InGameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        // int型のメッセージを登録する
        // UniRxのMessageBrokerのイメージ
        MessagePipeOptions options = builder.RegisterMessagePipe();
        builder.RegisterMessageBroker<int>(options);

        // エントリーポイントの登録
        builder.RegisterEntryPoint<IntEntryPoint>(Lifetime.Singleton);
    }
}
