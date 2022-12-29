using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stage3
{
    /// <summary>
    /// �ėp�I�ȃX�e�[�g�}�V��
    /// </summary>
    public class StateMachine
    {
        /// <summary>���݂̃X�e�[�g</summary>
        State _currentState;
        /// <summary>���̃X�e�[�g�}�V���ɓo�^����X�e�[�g�̃Z�b�g</summary>
        //HashSet<State> _stateSet;

        public StateMachine(int capacity)
        {
            //_stateSet = new HashSet<State>(capacity);
        }

        /// <summary>�X�e�[�g���w�肵�Ďn�߂�</summary>
        public void Start(State state)
        {
            _currentState = state;
            _currentState.OnEnter();
        }

        /// <summary>���݂̃X�e�[�g���X�V����</summary>
        public void Update()
        {
            _currentState.OnUpdate();
        }

        ///// <summary>�J�ڂ�ǉ�����</summary>
        //public void AddTransition<TFrom, TTo>(int id) where TFrom : State
        //                                              where TTo   : State
        //{
        //    // ���g�p
        //}

        /// <summary>�J�ڂ�ǉ�����</summary>
        public void AddTransition(State from, State to, int id)
        {
            // ���̃X�e�[�g�}�V���Ŏg�p����X�e�[�g�Ƃ��Ēǉ�����
            //_stateSet.Add(from);
            //_stateSet.Add(to);

            // from �̈ړ���̃X�e�[�g�Ƃ��� to ��o�^����
            from.AddState(id, to);
        }

        ///// <summary>�ǂ̃X�e�[�g����ł��J�ڂł���J�ڂ�ǉ�����</summary>
        //public void AddAnyTransition<TTo>(int id) where TTo : State
        //{
        //    // ���g�p
        //}

        /// <summary>�w�肵��ID�̃X�e�[�g�ɑJ�ڂ���</summary>
        public void Transition(int id)
        {
            _currentState.OnExit();
            _currentState = _currentState.GetState(id);
            _currentState.OnEnter();
        }

        /// <summary>
        /// �e�X�e�[�g�̒��ۃN���X
        /// </summary>
        public abstract class State
        {
            /// <summary>�����^�̏����e�ʁA�����Ȃ��悤�ɐݒ肷��</summary>
            readonly int _capacity;
            /// <summary>���̃X�e�[�g�̑J�ڐ��ۑ����鎫���^</summary>
            Dictionary<int, State> _dic;
            /// <summary>���̃X�e�[�g���o�^����Ă���X�e�[�g�}�V��</summary>
            protected StateMachine _stateMachine;

            public State(int capacity, StateMachine stateMachine)
            {
                _capacity = capacity;
                _dic = new Dictionary<int, State>(capacity);
                _stateMachine = stateMachine;
            }

            /// <summary>�J�ڐ�̃X�e�[�g��ǉ�����</summary>
            public void AddState(int id, State state)
            {
                if (_dic.Count == _capacity)
                    Debug.LogWarning("�X�e�[�g���������e�ʂ��I�[�o�[���܂���: " + this);

                 _dic[id] = state;
            }

            /// <summary>�J�ڐ�̃X�e�[�g���擾����</summary>
            public State GetState(int id)
            {
                if (_dic.TryGetValue(id, out State value))
                {
                    return value;
                }
                else
                {
                    Debug.LogError("�Ή�����X�e�[�g������܂���: " + id);
                    return null;
                }
            }

            public abstract void OnEnter();
            public abstract void OnUpdate();
            public abstract void OnExit();
        }

        /// <summary>
        /// �ǂ̃X�e�[�g����ł��J�ڂł���J�ڂɎg���X�e�[�g
        /// </summary>
        class AnyState : State
        {
            public AnyState(int capacity, StateMachine stateMachine) : base(capacity, stateMachine) { }

            public override void OnEnter() { }
            public override void OnUpdate() { }
            public override void OnExit() { }
        }
    }
}
