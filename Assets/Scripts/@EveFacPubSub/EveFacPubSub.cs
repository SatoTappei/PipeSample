using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MessagePipe;
using VContainer.Unity;

/// <summary>
/// �C�x���g�t�@�N�g���[��MessagePipe�g�p��:Pub&Sub
/// </summary>
public class EveFacPubSub : IStartable, IDisposable, ITickable
{
    int _count;

    IDisposablePublisher<int> _publisher;
    public ISubscriber<int> Subscriber { get; }

    // ��ȕύX�_�͈�����EventFactory�^���Ƃ�������
    public EveFacPubSub(EventFactory factory)
    {
        // �߂�l��tuple
        (_publisher, Subscriber) = factory.CreateEvent<int>();
    }


    public void Dispose()
    {
        _publisher.Dispose();
    }

    public void Start()
    {
        Subscriber.Subscribe(i =>
        {
            Debug.Log(i + "Subscribe");
        });
    }

    public void Tick()
    {
        _publisher.Publish(_count++);
    }
}
