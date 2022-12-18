using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MessagePipe;
using VContainer.Unity;
using System;
using Cysharp.Threading.Tasks;

/// <summary>
/// �A�C�e���֌W�̃C�x���g�̑��M���s���A�G���g���[�|�C���g
/// </summary>
public sealed class IntEntryPoint : IStartable, IDisposable
{
    /// <summary>MessagePipe�Ƀ��b�Z�[�W�𗬂���(Pub)�̃C���^�[�t�F�[�X</summary>
    readonly IPublisher<int> _publisher;
    /// <summary>MessagePipe���烁�b�Z�[�W���󂯎�鑤(Sub)�̃C���^�[�t�F�[�X</summary>
    readonly ISubscriber<int> _subscriber;

    IDisposable _disposable;

    /// <summary>�R���X�g���N�^�Ń��b�Z�[�W��z�M����Publisher��n��</summary>
    public IntEntryPoint(IPublisher<int> publisher, ISubscriber<int> subscriber)
    {
        _publisher = publisher;
        _subscriber = subscriber;
    }

    public void Start()
    {
        // �C�x���g�̓o�^����������ꍇ�Ɉꊇ�łł���DisposableBag�N���X���g��
        DisposableBagBuilder builder = DisposableBag.CreateBuilder();

        _subscriber.Subscribe(x =>
        {
            Debug.Log(x);
        }).AddTo(builder);

        // Dispose�o����悤��Build()�̖߂�l���󂯎��
        _disposable = builder.Build();

        PublishAsync();
    }

    public void Dispose()
    {
        // ���̃N���X�̃��b�Z�[�W�͂����󂯎��Ȃ��̂�Dispose����
        _disposable?.Dispose();
    }

    async void PublishAsync()
    {
        _publisher.Publish(10);
        await UniTask.Delay(500);
        _publisher.Publish(20);
        await UniTask.Delay(500);
        _publisher.Publish(30);
    }
}
