using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MessagePipe;
using VContainer.Unity;

/// <summary>
/// イベントファクトリーのMessagePipe使用例:Pub&Sub
/// </summary>
public class EveFacPubSub : IStartable, IDisposable, ITickable
{
    int _count;

    IDisposablePublisher<int> _publisher;
    public ISubscriber<int> Subscriber { get; }

    // 主な変更点は引数がEventFactory型だということ
    public EveFacPubSub(EventFactory factory)
    {
        // 戻り値がtuple
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
