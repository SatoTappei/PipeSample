using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MessagePipe;
using VContainer.Unity;
using System;
using Cysharp.Threading.Tasks;

/// <summary>
/// アイテム関係のイベントの送信を行う、エントリーポイント
/// </summary>
public sealed class IntEntryPoint : IStartable, IDisposable
{
    /// <summary>MessagePipeにメッセージを流す側(Pub)のインターフェース</summary>
    readonly IPublisher<int> _publisher;
    /// <summary>MessagePipeからメッセージを受け取る側(Sub)のインターフェース</summary>
    readonly ISubscriber<int> _subscriber;

    IDisposable _disposable;

    /// <summary>コンストラクタでメッセージを配信するPublisherを渡す</summary>
    public IntEntryPoint(IPublisher<int> publisher, ISubscriber<int> subscriber)
    {
        _publisher = publisher;
        _subscriber = subscriber;
    }

    public void Start()
    {
        // イベントの登録を解除する場合に一括でできるDisposableBagクラスを使う
        DisposableBagBuilder builder = DisposableBag.CreateBuilder();

        _subscriber.Subscribe(x =>
        {
            Debug.Log(x);
        }).AddTo(builder);

        // Dispose出来るようにBuild()の戻り値を受け取る
        _disposable = builder.Build();

        PublishAsync();
    }

    public void Dispose()
    {
        // このクラスのメッセージはもう受け取らないのでDisposeする
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
