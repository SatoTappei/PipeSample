using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MessagePipe;
using System;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// �v���C���[���l������A�C�e��
/// </summary>
public class Item : MonoBehaviour
{

    void Start()
    {
        this.OnTriggerEnter2DAsObservable()
            .Subscribe(c =>
            {
                if (c.gameObject.CompareTag("Player"))
                {
                    // �����Ɋl��������ǉ�
                    Destroy(gameObject);
                }
            });
    }
}
