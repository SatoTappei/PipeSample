using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MessagePipe;
using VContainer;

/// <summary>
/// �A�C�e�����擾�������Ƃ�UI�֔��f����:Presenter
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
            _view.Print(s + "����ɓ��ꂽ�I");
        }).AddTo(builder);

        _disposable = builder.Build();
    }

    void OnDestroy()
    {
        _disposable.Dispose();
    }
}
