using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.Events;
using System;

/// <summary>
/// MessageData型のメッセージを受け取る
/// </summary>
public class MessageDataSubscriber : MonoBehaviour
{
    [Header("メッセージを受け取ったときの処理")]
    [SerializeField] UnityEvent<MessageData> _onReceived;

    IDisposable _disposable;

    void Awake()
    {
        _disposable = MessageBroker.Default.Receive<MessageData>().Subscribe(messageData =>
                      {
                          _onReceived.Invoke(messageData);
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
