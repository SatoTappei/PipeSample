using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.Events;
using System;

// ”š’e‚ª”š”­‚µ‚½‚Æ‚«‚É‚È‚ñ‚©‚·‚é
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
        Debug.Log("‚Ù‚°‚Ù‚°");
    }
}
