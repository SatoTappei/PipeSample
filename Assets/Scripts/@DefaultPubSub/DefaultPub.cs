using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using MessagePipe;

/// <summary>
/// ものびを継承した場合のMessagePipe使用例:Pub
/// </summary>
public class DefaultPub : MonoBehaviour
{
    [Inject] IPublisher<int> _publisher;
    int _num;

    void Start()
    {
        _num = 0;
    }

    void Update()
    {
        // Zを押すとパブリッシュされる
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _num++;
            _publisher.Publish(_num);
        }
    }
}
