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
        // ����
        // _subscriber�ϐ���null
        // InGameLifetimeScope��Provider���N�����Ă��� OK
        // Provider�͖��t���[�����b�Z�[�W��MessagePipe�ɗ����Ă��� OK
        // �܂�
        // _subscriber�ϐ���null�����痬��Ă��郁�b�Z�[�W���󂯎��Ȃ�

        
    }

    void Update()
    {
        // Start���ƃR�[������鏇�ԂŖ�肪�o�Ă���\��������̂�
        // �L�[����������T�u�X�N�����悤�ɂ��Ă���(�e�X�g�p)
        if(Input.GetKeyDown(KeyCode.Space))
            // �X�R�A�̒l���������\���̂��󂯎���
            _subscriber.Subscribe(Hoge).AddTo(this.GetCancellationTokenOnDestroy());
    }

    void Hoge(ItemData data)
    {
        Debug.Log(data.Score);
    }
}
