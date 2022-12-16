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
    [SerializeField] ItemEventReceiver _receiver;

    protected override void Configure(IContainerBuilder builder)
    {
        // MessagePipeの設定
        MessagePipeOptions options = builder.RegisterMessagePipe();
        // ItemData(受け取ってほしいメッセージ)を伝達できるように設定する
        builder.RegisterMessageBroker<ItemData>(options);
        // メッセージを送信するProviderを起動する
        // ITickableインターフェースを実装してメッセージを作成、パイプに流す
        builder.RegisterEntryPoint<ItemEventProvider>(Lifetime.Singleton);
        // DI(依存性の注入)しながらInstantiate
        builder.RegisterBuildCallback(resolver =>
        {
            resolver.Instantiate(_receiver);
        });
    }
}
