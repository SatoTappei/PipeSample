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
    [SerializeField] ItemEventReceiver _receiver;

    protected override void Configure(IContainerBuilder builder)
    {
        // MessagePipe�̐ݒ�
        MessagePipeOptions options = builder.RegisterMessagePipe();
        // ItemData(�󂯎���Ăق������b�Z�[�W)��`�B�ł���悤�ɐݒ肷��
        builder.RegisterMessageBroker<ItemData>(options);
        // ���b�Z�[�W�𑗐M����Provider���N������
        // ITickable�C���^�[�t�F�[�X���������ă��b�Z�[�W���쐬�A�p�C�v�ɗ���
        builder.RegisterEntryPoint<ItemEventProvider>(Lifetime.Singleton);
        // DI(�ˑ����̒���)���Ȃ���Instantiate
        builder.RegisterBuildCallback(resolver =>
        {
            resolver.Instantiate(_receiver);
        });
    }
}
