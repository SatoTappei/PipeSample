//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using State = StateMachine<Actor>.State;

///// <summary>
///// �ėp�^�X�e�[�g�}�V���𗘗p���鑤�̃R���|�[�l���g
///// </summary>
//public class Actor : MonoBehaviour
//{
//    /// <summary>��Ԃ�\���񋓌^</summary>
//    enum Event : int
//    {
//        Timeout,
//        FindEnemy,
//        DefeatEnemy,
//        DefeatAllEnemy,
//    }

//    /// <summary>���̏�ŉ�]����N���X</summary>
//    class StateRotation : State
//    {

//    }

//    /// <summary>�O�i����N���X</summary>
//    class StateMoveForward : State
//    {
//        // ���Ԑ؂�ɂ�莞�Ԑ؂�X�e�[�g�Ɉڍs���鏈��
//    }

//    /// <summary>�I��</summary>
//    class StateEnd : State
//    {
//        // �X�N���v�g���A�N�e�B�u�ɂ���
//    }

//    /// <summary>Actor�^�̃X�e�[�g�}�V��</summary>
//    StateMachine<Actor> _stateMachine;

//    void Start()
//    {
//        // ���݂̃X�e�[�g�ƑJ�ڐ�̃X�e�[�g��ID�Ƃ��Ďg���C�x���g�̗񋓌^��o�^����
//        _stateMachine = new StateMachine<Actor>(this);
//        _stateMachine.AddTransition<StateRotation, StateMoveForward>((int)Event.FindEnemy);
//        _stateMachine.AddTransition<StateMoveForward, StateRotation>((int)Event.DefeatEnemy);
//        _stateMachine.AddTransition<StateMoveForward, StateRotation>((int)Event.Timeout);

//        // �ǂ̃X�e�[�g����ł��J�ڂł���X�e�[�g��o�^����
//        _stateMachine.AddAnyTransition<StateEnd>((int)Event.DefeatAllEnemy);

//        // �X�e�[�g�}�V���̋N�_��ݒ肷��
//        _stateMachine.Start<StateRotation>();
//    }

//    //void Update()
//    //{
//    //    // TODO:�G���S�ł��Ă�����return����

//    //    _stateMachine.Update();

//    //    // �e�X�e�[�g�N���X�ɑJ�ڏ������������A�X�e�[�g�}�V�����Ăяo�����ɏ���
//    //    if (Input.GetKeyDown(KeyCode.C)/* ���ۂ̑J�ڏ����̎d�g�݂����� */)
//    //    {
//    //        _stateMachine.Dispatch((int)Event.FindEnemy);
//    //    }
//    //}
//}
