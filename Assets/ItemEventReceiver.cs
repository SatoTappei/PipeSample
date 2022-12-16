using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using MessagePipe;
using VContainer;

/// <summary>
/// �A�C�e���̃C�x���g���󂯎���ăn���h�����O����
/// </summary>
public class ItemEventReceiver : MonoBehaviour
{
    /// <summary>MessagePipe���烁�b�Z�[�W���󂯎��C���^�[�t�F�[�X</summary>
    [Inject] ISubscriber<ItemData> _subscriber;

    void Start()
    {
        // �n���h�����O
        _subscriber.Subscribe(Hoge).AddTo(this.GetCancellationTokenOnDestroy());
    }

    void Update()
    {
        
    }

    void Hoge(ItemData data) { }
}
