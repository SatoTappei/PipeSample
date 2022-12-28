using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;

/// <summary>
/// ���b�Z�[�W�̃f�[�^
/// </summary>
public struct MessageData
{
    public MessageData(int value)
    {
        Value = value;
    }

    public int Value { get; }
}

/// <summary>
/// ��莞�Ԍ�Ƀ��b�Z�[�W�𔭍s����
/// </summary>
public class MessageDataPublisher : MonoBehaviour
{
    [SerializeField] int _delayFrame = 60;

    async UniTaskVoid Start()
    {
        await UniTask.DelayFrame(_delayFrame);
        MessageBroker.Default.Publish(new MessageData(100));
    }
}
