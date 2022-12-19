using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MessagePipe;
using VContainer.Unity;

/// <summary>
/// ���N�G�X�g/���X�|���X/�I�[����MessagePipe�g�p��:Presenter
/// </summary>
public class RRAPresenter : IStartable
{
    IRequestHandler<int, bool> _requestHandler;

    public RRAPresenter(IRequestHandler<int, bool> eventFactory)
    {
        // �C�x���g�t�@�N�g���[���n���h���Ƃ��ēn�����
        _requestHandler = eventFactory;
    }

    public void Start()
    {
        // �n���h���[�̃f���Q�[�g�����s����?
        bool pong = _requestHandler.Invoke(1);
        Debug.Log("PONG" + pong);
    }
}
