using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MessagePipe;
using System;

namespace Example
{
    /// <summary>
    /// 攻撃データ
    /// </summary>
    public class AttackData
    {
        public int Damage { get; set; }
    }

    /// <summary>
    /// ダメージを与える側のクラス
    /// </summary>
    public class DamageSender
    {
        readonly IPublisher<AttackData> Publisher;

        public DamageSender(IPublisher<AttackData> publisher)
        {
            Publisher = publisher;
        }

        public void OnAttack(int damage)
        {
            Publisher.Publish(new AttackData()
            {
                Damage = damage
            });
        }
    }

    /// <summary>
    /// ダメージを受ける側のクラス
    /// </summary>
    public class DamageReceiver : IDisposable
    {
        readonly ISubscriber<AttackData> Subscriber;

        IDisposable _disposable;
        string _name;
        int _hp;
        bool _isDead;

        public DamageReceiver(ISubscriber<AttackData> subscriber, string name, int hp)
        {
            Subscriber = subscriber;
            _name = name;
            _hp = hp;
            _isDead = false;

            // コンストラクタの中でメソッドを呼んでいる
            OnInitialize();
        }

        void OnInitialize()
        {
            DisposableBagBuilder builder = DisposableBag.CreateBuilder();

            Subscriber.Subscribe(attackData =>
            {
                Debug.Log(attackData.Damage);
            }).AddTo(builder);

            _disposable = builder.Build();
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}