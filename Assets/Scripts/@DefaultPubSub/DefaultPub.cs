using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using MessagePipe;

/// <summary>
/// ���̂т��p�������ꍇ��MessagePipe�g�p��:Pub
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
        // Z�������ƃp�u���b�V�������
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _num++;
            _publisher.Publish(_num);
        }
    }
}
