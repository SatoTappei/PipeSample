using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stage3
{
    using State = StateMachine.State;
    
    /// <summary>
    /// �v���C���[��������ƒǂ������Ă���G�̃R���|�[�l���g
    /// </summary>
    public class EnemyChaser : MonoBehaviour, IPauseable
    {
        enum StateID
        {
            Idle,
            Wander,
            Chase,
            Jump,
            End,
        }

        /// <summary>
        /// �A�C�h����Ԃ̃X�e�[�g
        /// </summary>
        class StateIdle : State, IMoveChaseable
        {
            public GameObject Actor { get; set; }
            public Transform Target { get; set; }
            public Rigidbody2D Rb { get; set; }

            /// <summary>�^�[�Q�b�g�Ƃ̋���������ȉ��ɂȂ�ƒǐՏ�ԂɑJ�ڂ���</summary>
            readonly float Range = 5f;

            public StateIdle(int capacity, StateMachine stateMachine, GameObject actor, Transform target, Rigidbody2D rb)
                : base(capacity, stateMachine)
            {
                Actor = actor;
                Target = target;
                Rb = rb;
            }

            public override void OnEnter()
            {
                //Rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
            }

            public override void OnUpdate()
            {
                // �m���ł��낤���ԂɑJ�ڂ���

                // �v���C���[����������ǐՏ�ԂɑJ�ڂ���
                if (Vector3.Distance(Actor.transform.position, Target.position) < Range)
                {
                    Debug.Log("�J��");
                    _stateMachine.Transition((int)StateID.Chase);
                }
            }

            public override void OnExit()
            {
                Debug.Log("�A�C�h����Ԃ��甲����");
            }
        }

        /// <summary>
        /// ���낤���Ԃ̃X�e�[�g
        /// </summary>
        class StateWander : State, IMoveChaseable
        {
            public GameObject Actor { get; set; }
            public Transform Target { get; set; }
            public Rigidbody2D Rb { get; set; }

            public StateWander(int capacity, StateMachine stateMachine, GameObject actor, Transform target, Rigidbody2D rb)
                : base(capacity, stateMachine)
            {
                Actor = actor;
                Target = target;
                Rb = rb;
            }

            public override void OnEnter()
            {

            }

            public override void OnUpdate()
            {
                // ���낤�낪�I�������A�C�h����ԂɑJ�ڂ���
                // �i������������W�����v������
            }

            public override void OnExit()
            {

            }
        }

        /// <summary>
        /// �v���C���[��ǐՂ��Ă����Ԃ̃X�e�[�g
        /// </summary>
        class StateChase : State, IMoveChaseable
        {
            public GameObject Actor { get; set; }
            public Transform Target { get; set; }
            public Rigidbody2D Rb { get; set; }

            public StateChase(int capacity, StateMachine stateMachine, GameObject actor, Transform target, Rigidbody2D rb)
                : base(capacity, stateMachine)
            {
                Actor = actor;
                Target = target;
                Rb = rb;
            }

            public override void OnEnter()
            {
                Debug.Log("�ǐՏ�Ԃɓ���");
            }

            public override void OnUpdate()
            {
                Debug.Log("�ǐՒ�");
            }

            public override void OnExit()
            {

            }
        }

        /// <summary>
        /// �W�����v���Ă����Ԃ̃X�e�[�g
        /// </summary>
        class StateJump : State, IMoveChaseable
        {
            public GameObject Actor { get; set; }
            public Transform Target { get; set; }
            public Rigidbody2D Rb { get; set; }

            public StateJump(int capacity, StateMachine stateMachine, GameObject actor, Transform target, Rigidbody2D rb)
                : base(capacity, stateMachine)
            {
                Actor = actor;
                Target = target;
                Rb = rb;
            }

            public override void OnEnter()
            {

            }

            public override void OnUpdate()
            {
                // �W�����v��̓A�C�h����ԂɑJ�ڂ���
            }

            public override void OnExit()
            {

            }
        }

        /// <summary>
        /// ����ȏ㓮�����Ȃ��ꍇ�ɑJ�ڂ����X�e�[�g
        /// </summary>
        class StateEnd : State
        {
            public StateEnd(int capacity, StateMachine stateMachine) : base(capacity, stateMachine) { }

            public override void OnEnter()
            {
                // �j������Ȃ�enabled����Ȃ�
            }

            public override void OnUpdate() { }
            public override void OnExit() { }
        }

        [Header("�e�X�e�[�g�ɓn���Q��")]
        [SerializeField] Transform _target;
        [SerializeField] Rigidbody2D _rb;

        /// <summary>�X�e�[�g�}�V���̑���͎g�����ōs��</summary>
        StateMachine _stateMachine;

        void Start()
        {
            _stateMachine = new StateMachine(4);

            // �C���X�^���X���������Ő������ēn��
            var idle = new StateIdle(2, _stateMachine, gameObject, _target, _rb);
            var wander = new StateWander(1, _stateMachine, gameObject, _target, _rb);
            var chase = new StateChase(1, _stateMachine, gameObject, _target, _rb);
            var jump = new StateJump(1, _stateMachine, gameObject, _target, _rb);
            
            // �A�C�h����Ԃ��� ���낤�� �ǐ� ��ԂɑJ�ڂł���
            _stateMachine.AddTransition(idle, wander, (int)StateID.Wander);
            _stateMachine.AddTransition(idle, chase, (int)StateID.Chase);
            // ���낤�� �ǐ� ��Ԃ̂Ƃ��͒i��������ƃW�����v����
            _stateMachine.AddTransition(wander, jump, (int)StateID.Jump);
            _stateMachine.AddTransition(chase, jump, (int)StateID.Jump);
            // �W�����v��̓A�C�h����Ԃɖ߂�
            // ���낤�낵�Ă����ꍇ�͎~�܂�A�ǐՂ��Ă����ꍇ�͒ǐՍĊJ
            _stateMachine.AddTransition(jump, idle, (int)StateID.Idle);

            _stateMachine.Start(idle);

            // �A�C�h����Ԃ��� ���낤�� �ǐ� ��ԂɑJ�ڂł���
            //_stateMachine.AddTransition<StateIdle, StateWander>((int)Event.Wander);
            //_stateMachine.AddTransition<StateIdle, StateChase>((int)Event.Chase);
            // ���낤�� �ǐ� ��Ԃ̂Ƃ��͒i��������ƃW�����v����
            //_stateMachine.AddTransition<StateWander, StateJump>((int)Event.Jump);
            //_stateMachine.AddTransition<StateChase, StateJump>((int)Event.Jump);
            // �W�����v��̓A�C�h����Ԃɖ߂�
            // ���낤�낵�Ă����ꍇ�͎~�܂�A�ǐՂ��Ă����ꍇ�͒ǐՍĊJ
            //_stateMachine.AddTransition<StateJump, StateIdle>((int)Event.Idle);

            // �����܂�
            //_stateMachine.AddAnyTransition<StateEnd>((int)Event.End);

            // �C�ӂ̃X�e�[�g����n�߂�
            //_stateMachine.Start<StateIdle>();
        }

        void FixedUpdate()
        {
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