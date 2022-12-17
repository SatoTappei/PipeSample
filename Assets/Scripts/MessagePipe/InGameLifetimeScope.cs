using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MessagePipe;
using VContainer;
using VContainer.Unity;

/// <summary>
/// �R���e�i
/// </summary>
public class InGameLifetimeScope : LifetimeScope
{
    [SerializeField] ItemEventReceiver _receiver;
    // �ȉ��e�X�g�p��Hoge�A���ۂ̃Q�[���ɂ͕K�v�Ȃ�
    [SerializeField] HogeView _hogeView;

    protected override void Configure(IContainerBuilder builder)
    {
        // MessagePipe�̐ݒ�
        MessagePipeOptions options = builder.RegisterMessagePipe();
        // ItemData(�󂯎���Ăق������b�Z�[�W)��`�B�ł���悤�ɐݒ肷��
        builder.RegisterMessageBroker<ItemData>(options);
        // ���b�Z�[�W�𑗐M����Provider���N������
        // ITickable�C���^�[�t�F�[�X���������ă��b�Z�[�W���쐬�A�p�C�v�ɗ���
        builder.RegisterEntryPoint<ItemEventPresenter>(Lifetime.Singleton);

        // �ȉ��e�X�g�p��Hoge�A���ۂ̃Q�[���ɂ͕K�v�Ȃ�
        builder.RegisterEntryPoint<HogePresenter>();
        builder.Register<ItemData>(Lifetime.Singleton);
        builder.RegisterComponent(_hogeView);

        // DI(�ˑ����̒���)���Ȃ���Instantiate
        //builder.RegisterBuildCallback(resolver =>
        //{
        //    resolver.Instantiate(_receiver);
        //});
    }
}
