using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using MessagePipe;
using System;

/// <summary>
/// Ç‡ÇÃÇ—Çåpè≥ÇµÇΩèÍçáÇÃMessagePipeégópó·:Sub
/// </summary>
public class DefaultSub : MonoBehaviour
{
    [Inject] ISubscriber<int> _subscriber;
    IDisposable _disposable;

    void Start()
    {
        DisposableBagBuilder builder = DisposableBag.CreateBuilder();
        _subscriber.Subscribe(i =>
        {
            Debug.Log("Subscribe: " + i);
        }).AddTo(builder);

        _disposable = builder.Build();
    }

    void OnDestroy()
    {
        _disposable.Dispose();
    }
}
