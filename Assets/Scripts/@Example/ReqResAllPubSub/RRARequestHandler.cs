using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MessagePipe;

/// <summary>
/// リクエスト/レスポンス/オールのMessagePipe使用例:
/// </summary>
public class RRARequestHandler : MonoBehaviour, IRequestHandler<int, bool>
{
    public bool Invoke(int request)
    {
        Debug.Log("PONG" + request);
        return true;
    }
}
