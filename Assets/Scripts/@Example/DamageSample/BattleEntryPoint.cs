using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MessagePipe;
using VContainer.Unity;

namespace Example
{
    /// <summary>
    /// �G���g���[�|�C���g
    /// </summary>
    public class BattleEntryPoint : IStartable, ITickable
    {
        readonly IPublisher<AttackData> Publisher;
        readonly ISubscriber<AttackData> Subscriber;

        DamageSender _damageSender;
        DamageReceiver _damageReceiver;

        /// <summary>
        /// AttackData������肷�邽�߂�Pub��Sub�̃C���^�[�t�F�[�X���n����Ă���
        /// </summary>
        /// <param name="publisher">�G���g���[�|�C���g�Ȃ̂ŃR���e�i����n�����</param>
        /// <param name="subscriber">�G���g���[�|�C���g�Ȃ̂ŃR���e�i����n�����</param>
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