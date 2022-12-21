using VContainer;
using VContainer.Unity;
using MessagePipe;

/// <summary>
/// ���N�G�X�g/���X�|���X/�I�[����MessagePipe�g�p��:�炢�ӂ����[��
/// </summary>
public class RRALifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        // �p�C�v�̃I�v�V����
        MessagePipeOptions options = builder.RegisterMessagePipe();
        // ���b�Z�[�W�̌^�A�ԓ��̌^�A�Ȃ񂩏������ĕԓ����郁�\�b�h(Invoke)��
        // �����ꂽ�N���X��o�^����
        builder.RegisterRequestHandler<int, bool, RRARequestHandler>(options);
        // �G���g���[�|�C���g�Ƃ���Presenter��
        builder.RegisterEntryPoint<RRAPresenter>(Lifetime.Scoped);
    }
}
