using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MessagePipe;
using System;

namespace Example
{
    /// <summary>
    /// �U���f�[�^
    /// </summary>
    public class AttackData
    {
        public int Damage { get; set; }
    }

    /// <summary>
    /// �_���[�W��^���鑤�̃N���X
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
    /// �_���[�W���󂯂鑤�̃N���X
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

            // �R���X�g���N�^�̒��Ń��\�b�h���Ă�ł���
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