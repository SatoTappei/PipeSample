using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UniRx;

/// <summary>
/// UniTaskを使っているコンポーネント
/// </summary>
public class UniTasker : MonoBehaviour
{
    async UniTaskVoid Start()
    {
        System.IObservable<string> obs = Observable.Return("Hoge");

        await obs;
        Debug.Log(obs);

        UniTask<string> uniTask = obs.ToUniTask();

        await uniTask;

        System.IObservable<string> obs2 = uniTask.ToObservable();

        await obs2;

        Debug.Log("終了");
    }

    void Work(object n)
    {
        for(int i = 0; i < 10; i++)
        {
            Debug.Log(i);
        }
    }

    async UniTask WaitAsync()
    {
        await UniTask.DelayFrame(60);
    }
}
