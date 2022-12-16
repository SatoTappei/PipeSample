using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MessagePipe;
using System;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// プレイヤーが獲得するアイテム
/// </summary>
public class Item : MonoBehaviour
{

    void Start()
    {
        this.OnTriggerEnter2DAsObservable()
            .Subscribe(c =>
            {
                if (c.gameObject.CompareTag("Player"))
                {
                    // ここに獲得処理を追加
                    Destroy(gameObject);
                }
            });
    }
}
