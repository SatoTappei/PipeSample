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
        /// <summary>�X�e�[�g�̍��v���A�J�ڐ���i�[���鎫���^�̏����e�ʂɎg��</summary>
        readonly int Total;

        State _currentState;
        /// <summary>�ǂ̃X�e�[�g����ł��o����J�ڂ̋N�_�ƂȂ�X�e�[�g</summary>
        State _anyState;

        public StateMachine(int total)
        {
            Total = total;
            _anyState = new AnyState();
            _anyState.Dic = new Dictionary<int, State>(Total);
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

        /// <summary>�n���ꂽ�^�̃X�e�[�g�̃C���X�^���X�𐶐����ĕԂ�</summary>
        public T Instantiate<T>(params Object[] objs) where T : State, new()
        {
            T state = new T();

            // �R���X�g���N�^���g���Ȃ��̂Ńv���p�e�B�ƃ��\�b�h���g�p���ăt�B�[���h�ɑ��
            state.Dic = new Dictionary<int, State>(Total);
            state.StateMachine = this;
            state.SetField(objs);

            return state;
        }

        /// <summary>�J�ڂ�ǉ�����</summary>
        public void AddTransition(int id, State from, State to) => from.AddState(id, to);

        /// <summary>�ǂ̃X�e�[�g����ł��o����J�ڂ�ǉ�����</summary>
        public void AddAnyTransition(int id, State to) => _anyState.AddState(id, to);

        /// <summary>�w�肵��ID�̃X�e�[�g�ɑJ�ڂ���</summary>
        public void Transition(int id) => Transition(_currentState, id);

        /// <summary>�w�肵��ID�̃X�e�[�g�ɁA�ǂ̃X�e�[�g����ł��o����J�ڂ��s��</summary>
        public void AnyTransition(int id) => Transition(_anyState, id);

        /// <summary>���̃X�e�[�g�ɑJ�ڂ���ۂ̏���</summary>
        void Transition(State state, int id)
        {
            _currentState.OnExit();
            _currentState = state.GetState(id);
            _currentState.OnEnter();
        }

        /// <summary>
        /// �e�X�e�[�g�̒��ۃN���X
        /// </summary>
        public abstract class State
        {
            /// <summary>���̃X�e�[�g�̑J�ڐ��ۑ����鎫���^</summary>
            Dictionary<int, State> _dic;
            /// <summary>���̃X�e�[�g���o�^����Ă���X�e�[�g�}�V��</summary>
            StateMachine _stateMachine;

            // 1�x���������đ���ł��Ȃ��v���p�e�B
            public Dictionary<int, State> Dic
            {
                get => _dic;
                set => _dic = _dic ?? value;
            }
            public StateMachine StateMachine
            {
                get => _stateMachine;
                set => _stateMachine = _stateMachine ?? value;
            }

            /// <summary>�J�ڐ�̃X�e�[�g��ǉ�����</summary>
            public void AddState(int id, State state) => Dic[id] = state;

            /// <summary>�J�ڐ�̃X�e�[�g���擾����</summary>
            public State GetState(int id)
            {
                if (Dic.TryGetValue(id, out State value))
                {
                    return value;
                }
                else
                {
                    Debug.LogError("�Ή�����X�e�[�g������܂���: " + id);
                    return null;
                }
            }

            /// <summary>��������R���X�g���N�^���g���Ȃ��̂Ń��\�b�h�Ńt�B�[���h�ւ̎Q�Ƃ�n��</summary>
            /// <param name="objs">���݂̗̑͂ȂǁA�l�^�ɂ͑Ή����Ă��Ȃ�</param>
            public abstract void SetField(params Object[] objs);
            
            public abstract void OnEnter();
            public abstract void OnUpdate();
            public abstract void OnExit();
        }

        /// <summary>
        /// �ǂ̃X�e�[�g����ł��J�ڂł���J�ڂɎg���X�e�[�g
        /// </summary>
        class AnyState : State
        {
            public override void SetField(params Object[] objs) { }
            public override void OnEnter() { }
            public override void OnUpdate() { }
            public override void OnExit() { }
        }
    }
}
