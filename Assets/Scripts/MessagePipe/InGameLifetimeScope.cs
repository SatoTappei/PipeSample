using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MessagePipe;
using VContainer;
using VContainer.Unity;

/// <summary>
/// �R���e�i
/// </summary>
public class InGameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        // int�^�̃��b�Z�[�W��o�^����
        // UniRx��MessageBroker�̃C���[�W
        MessagePipeOptions options = builder.RegisterMessagePipe();
        builder.RegisterMessageBroker<int>(options);

        // �G���g���[�|�C���g�̓o�^
        builder.RegisterEntryPoint<IntEntryPoint>(Lifetime.Singleton);
    }
}
