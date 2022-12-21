using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MessagePipe;
using VContainer;

/// <summary>
/// アイテムを取得したことをUIへ反映する:Presenter
/// </summary>
public class MessageLogPresenter : MonoBehaviour
{
    [Inject] ISubscriber<string> _subscriber;
    [SerializeField] MessageLogView _view;

    IDisposable _disposable;

    void Start()
    {
        DisposableBagBuilder builder = DisposableBag.CreateBuilder();
        _subscriber.Subscribe(s => 
        {
            _view.Print(s + "を手に入れた！");
        }).AddTo(builder);

        _disposable = builder.Build();
    }

    void OnDestroy()
    {
        _disposable.Dispose();
    }
}
