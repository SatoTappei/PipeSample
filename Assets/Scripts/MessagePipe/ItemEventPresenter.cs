using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MessagePipe;
using VContainer.Unity;

/// <summary>
/// アイテム関係のイベントの送信を行う、エントリーポイント
/// </summary>
public sealed class ItemEventPresenter : ITickable
{
    /// <summary>MessagePipeにメッセージを流す用のインターフェース</summary>
    readonly IPublisher<ItemData> _itemPublisher;

    /// <summary>コンストラクタでメッセージを配信するPublisherを渡す</summary>
    public ItemEventPresenter(IPublisher<ItemData> publisher)
    {
        _itemPublisher = publisher;
    }

    /// <summary>毎フレーム、Update()のタイミングで呼ばれる</summary>
    public void Tick()
    {
        // MessagePipeにメッセージ(構造体)を送信
        _itemPublisher.Publish(new ItemData(100));
    }
}
