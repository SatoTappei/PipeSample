using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MessagePipe;

/// <summary>
/// ���N�G�X�g/���X�|���X/�I�[����MessagePipe�g�p��:
/// </summary>
public class RRARequestHandler : MonoBehaviour, IRequestHandler<int, bool>
{
    public bool Invoke(int request)
    {
        Debug.Log("PONG" + request);
        return true;
    }
}
