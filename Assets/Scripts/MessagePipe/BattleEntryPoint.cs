using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MessagePipe;
using VContainer.Unity;

namespace Example
{
    /// <summary>
    /// エントリーポイント
    /// </summary>
    public class BattleEntryPoint : IStartable, ITickable
    {
        readonly IPublisher<AttackData> Publisher;
        readonly ISubscriber<AttackData> Subscriber;

        DamageSender _damageSender;
        DamageReceiver _damageReceiver;

        /// <summary>
        /// AttackDataをやり取りするためにPubとSubのインターフェースが渡されてくる
        /// </summary>
        /// <param name="publisher">エントリーポイントなのでコンテナから渡される</param>
        /// <param name="subscriber">エントリーポイントなのでコンテナから渡される</param>
        public BattleEntryPoint(IPublisher<AttackData> publisher, ISubscriber<AttackData> subscriber)
        {
            Publisher = publisher;
            Subscriber = subscriber;
        }

        public void Start()
        {
            _damageSender = new DamageSender(Publisher);
            _damageReceiver = new DamageReceiver(Subscriber, "hoge", 100);
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                _damageSender.OnAttack(100);
            }
        }
    }
}