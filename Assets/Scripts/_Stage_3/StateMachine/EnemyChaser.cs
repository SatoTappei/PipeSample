using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stage3
{
    /// <summary>
    /// �v���C���[��������ƒǂ������Ă���G�̃R���|�[�l���g
    /// �eState��EnemyChaserState.cs�ɕ���
    /// </summary>
    public partial class EnemyChaser : MonoBehaviour, IPauseable
    {
        enum StateID
        {
            Idle,
            Wander,
            Chase,
            Jump,
            End,
        }

        [Header("�e�X�e�[�g�ɓn���Q��")]
        [SerializeField] Transform _target;
        [SerializeField] Rigidbody2D _rb;

        /// <summary>�X�e�[�g�}�V���̑���͎g�����ōs��</summary>
        StateMachine _stateMachine;

        // �e�X�g:���ؗp�̉��̎��S�t���O�A���؂��I����������
        bool _isDead;

        void Start()
        {
            _stateMachine = new StateMachine(5);

            // �e�X�e�[�g�̃C���X�^���X�𐶐�����
            StateIdle idle     = _stateMachine.Instantiate<StateIdle>  (gameObject, _target, _rb);
            StateWander wander = _stateMachine.Instantiate<StateWander>(gameObject, _target, _rb);
            StateChase chase   = _stateMachine.Instantiate<StateChase> (gameObject, _target, _rb);
            StateJump jump     = _stateMachine.Instantiate<StateJump>  (gameObject, _target, _rb);
            StateEnd end       = _stateMachine.Instantiate<StateEnd>   ();

            // �A�C�h����Ԃ��� ���낤�� �ǐ� ��ԂɑJ�ڂł���
            _stateMachine.AddTransition((int)StateID.Wander, idle, wander);
            _stateMachine.AddTransition((int)StateID.Chase, idle, chase);
            // �ǐՏ�Ԃ̂Ƃ��Ƀv���C���[�ƈ��ȏ㋗���������ƃA�C�h����ԂɑJ�ڂ���
            _stateMachine.AddTransition((int)StateID.Idle, chase, idle);
            // ���낤�� �ǐ� ��Ԃ̂Ƃ��͒i��������ƃW�����v����
            _stateMachine.AddTransition((int)StateID.Jump, wander, jump);
            _stateMachine.AddTransition((int)StateID.Jump, chase, jump);
            // �W�����v��̓A�C�h����Ԃɖ߂�
            // ���낤�낵�Ă����ꍇ�͎~�܂�A�ǐՂ��Ă����ꍇ�͒ǐՍĊJ
            _stateMachine.AddTransition((int)StateID.Idle, jump, idle);

            // �ǂ̏�Ԃł����S�����ꍇ�͎��S��ԂɑJ�ڂ���
            _stateMachine.AddAnyTransition((int)StateID.End, end);

            _stateMachine.Start(idle);
        }

        void Update()
        {
            // �e�X�g�p�A�S���̎��S�t���O�𗧂Ă�
            if (Input.GetKeyDown(KeyCode.Q) && !_isDead)
            {
                _isDead = true;
            }
        }

        void FixedUpdate()
        {
            // ����ł��Ȃ����`�F�b�N
            if (_isDead)
            {
                _stateMachine.AnyTransition((int)StateID.End);
                //_stateMachine.AnyTransition((int)StateID.End, end);
            }

            // ���W�{���g���Ĉړ������Ă���̂ł������ŌĂ�ł���
            // ���AUpdate()�ŌĂԏ����ƕ�������
            _stateMachine.Update();
        }

        public void Pause()
        {
            // �|�[�Y���̏���
        }

        public void Release()
        {
            // �|�[�Y�������̏���
        }
    }
}