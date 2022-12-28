using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MessagePipe;
using VContainer.Unity;

/// <summary>
/// リクエスト/レスポンス/オールのMessagePipe使用例:Presenter
/// </summary>
public class RRAPresenter : IStartable
{
    IRequestHandler<int, bool> _requestHandler;

    public RRAPresenter(IRequestHandler<int, bool> eventFactory)
    {
        // イベントファクトリーがハンドラとして渡される
        _requestHandler = eventFactory;
    }

    public void Start()
    {
        // ハンドラーのデリゲートを実行する?
        bool pong = _requestHandler.Invoke(1);
        Debug.Log("PONG" + pong);
    }
}
