using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UniRx;
using MessagePipe;
using VContainer;

/// <summary>
/// �A�C�e�����Ƃ����Ƃ��Ƀ��A�N�V������������R���|�[�l���g
/// </summary>
public class PlayerReaction : MonoBehaviour
{
    [Inject] ISubscriber<string> _subscriber;
    [SerializeField] Text _text;

    IDisposable _disposable;

    void Start()
    {
        // �A�C�e���l�����ɃA�C�e�����𓪏�ɕ\������
        DisposableBagBuilder builder = DisposableBag.CreateBuilder();
        _subscriber.Subscribe(s => _text.text = s).AddTo(builder);

        _disposable = builder.Build();
    }

    void OnDestroy()
    {
        _disposable.Dispose();
    }
}
