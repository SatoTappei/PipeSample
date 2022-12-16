using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MessagePipe;
using System;

/// <summary>
/// プレイヤーが獲得するアイテム
/// </summary>
public class Item : MonoBehaviour
{
    //float _random = 0.0f;
    //float _speed = 1.0f;
    //// 購読する側のインターフェース
    //ISubscriber<ItemData> ItemData { get; set; }
    //// オブジェクトが削除されたタイミングで破棄される
    //IDisposable _disposable;

    //public void SetUp(ISubscriber<ItemData> data)
    //{
    //    ItemData = data;
    //    var d = DisposableBag.CreateBuilder();
    //    ItemData.Subscribe(ev =>
    //    {
    //        //_speed = ev._value;
    //    }).AddTo(d);

    //    _disposable = d.Build();
    //}

    //void Start()
    //{
    //    // 作りたい挙動
    //    // アイテムを獲得したらUIに情報を表示したい
    //}

    //void Update()
    //{
        
    //}

    //void OnDestroy()
    //{
    //    _disposable.Dispose();
    //}
}
