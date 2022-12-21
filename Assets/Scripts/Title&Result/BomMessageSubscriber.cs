using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.Events;
using System;

// 爆弾が爆発したときになんかする
public class BomMessageSubscriber : MonoBehaviour
{
    [SerializeField] UnityEvent _onReceived;

    IDisposable _disposable;

    void Awake()
    {
        _disposable = MessageBroker.Default.Receive<BomData>().Subscribe(bomData =>
                      {
                          _onReceived.Invoke();
                      });
    }

    void Start()
    {
        
    }

    void OnDestroy()
    {
        _disposable.Dispose();
    }

    public void Hoge()
    {
        Debug.Log("ほげほげ");
    }
}
