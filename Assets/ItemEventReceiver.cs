using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using MessagePipe;
using VContainer;

/// <summary>
/// アイテムのイベントを受け取ってハンドリングする
/// </summary>
public class ItemEventReceiver : MonoBehaviour
{
    /// <summary>MessagePipeからメッセージを受け取るインターフェース</summary>
    [Inject] ISubscriber<ItemData> _subscriber;

    void Start()
    {
        // ハンドリング
        _subscriber.Subscribe(Hoge).AddTo(this.GetCancellationTokenOnDestroy());
    }

    void Update()
    {
        
    }

    void Hoge(ItemData data) { }
}
