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
        // 現状
        // _subscriber変数がnull
        // InGameLifetimeScopeはProviderを起動している OK
        // Providerは毎フレームメッセージをMessagePipeに流している OK
        // つまり
        // _subscriber変数がnullだから流れてくるメッセージを受け取れない

        
    }

    void Update()
    {
        // Startだとコールされる順番で問題が出ている可能性があるので
        // キーを押したらサブスクされるようにしている(テスト用)
        if(Input.GetKeyDown(KeyCode.Space))
            // スコアの値が入った構造体が受け取れる
            _subscriber.Subscribe(Hoge).AddTo(this.GetCancellationTokenOnDestroy());
    }

    void Hoge(ItemData data)
    {
        Debug.Log(data.Score);
    }
}
