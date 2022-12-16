using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MessagePipe;
using VContainer.Unity;

/// <summary>
/// �A�C�e���֌W�̃C�x���g�̑��M���s��
/// </summary>
public sealed class ItemEventProvider : ITickable
{
    /// <summary>MessagePipe�Ƀ��b�Z�[�W�𗬂��p�̃C���^�[�t�F�[�X</summary>
    readonly IPublisher<ItemData> _itemPublisher;

    /// <summary>�R���X�g���N�^�Ń��b�Z�[�W��z�M����Publisher��n��</summary>
    public ItemEventProvider(IPublisher<ItemData> publisher)
    {
        _itemPublisher = publisher;
    }

    /// <summary>���t���[���Ă΂��</summary>
    public void Tick()
    {
        // MessagePipe�Ƀ��b�Z�[�W(�\����)�𑗐M
        _itemPublisher.Publish(new ItemData(100));
    }
}
