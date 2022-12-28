using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;

/// <summary>
/// メッセージのデータ
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
/// 一定時間後にメッセージを発行する
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
