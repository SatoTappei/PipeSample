using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MessagePipe;
using VContainer;
using VContainer.Unity;
using Cysharp.Threading.Tasks;
using System.Threading;

/// <summary>
/// 箱を生成するコンポーネント
/// </summary>
public class Generator : MonoBehaviour, ISwitchable
{
    [Inject] IObjectResolver _resolver;
    [SerializeField] GameObject _go;

    public void OnSwitchOn()
    {
        _resolver.Instantiate(_go, transform.position, Quaternion.identity);
    }

    public void OnSwitchOff()
    {
        // 未実装
    }
}
