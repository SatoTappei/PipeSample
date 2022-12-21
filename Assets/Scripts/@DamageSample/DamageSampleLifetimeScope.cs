using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MessagePipe;
using VContainer;
using VContainer.Unity;

namespace Example
{
    /// <summary>
    /// �R���e�i
    /// </summary>
    public class DamageSampleLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // int�^�̃��b�Z�[�W��o�^����
            // UniRx��MessageBroker�̃C���[�W
            MessagePipeOptions options = builder.RegisterMessagePipe();
            builder.RegisterMessageBroker<AttackData>(options);

            // �G���g���[�|�C���g�̓o�^
            builder.RegisterEntryPoint<BattleEntryPoint>();
        }
    }
}