using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MessagePipe;
using VContainer;
using VContainer.Unity;

namespace Example
{
    /// <summary>
    /// コンテナ
    /// </summary>
    public class DamageSampleLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // int型のメッセージを登録する
            // UniRxのMessageBrokerのイメージ
            MessagePipeOptions options = builder.RegisterMessagePipe();
            builder.RegisterMessageBroker<AttackData>(options);

            // エントリーポイントの登録
            builder.RegisterEntryPoint<BattleEntryPoint>();
        }
    }
}