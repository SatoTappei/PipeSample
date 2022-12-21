using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;

public struct BomData
{
    public BomData(int penalty)
    {
        Penalty = penalty;
    }

    public int Penalty { get; }
}

public class BomMessagePublisher : MonoBehaviour
{
    async UniTaskVoid Start()
    {
        await UniTask.DelayFrame(60);
        MessageBroker.Default.Publish(new BomData(3));
    }
}
