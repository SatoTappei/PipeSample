//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

///// <summary>
///// �ėp�I�X�e�[�g�}�V��
///// </summary>
//public class StateMachine<TOwner>
//{
//    TOwner Owner { get; }

//    public StateMachine(TOwner owner)
//    {
//        Owner = owner;
//    }

//    public T Add<T>() where T : State, new()
//    {
//        T state = new T();
//        state.
//    }

//    /// <summary>�X�e�[�g��\���N���X</summary>
//    public abstract class State
//    {
//        protected StateMachine<TOwner> StateMachine => stateMachine;
//        internal StateMachine<TOwner> stateMachine;

//        internal void Enter(State prevState)
//        {
//            OnEnter(prevState);
//        }

//        protected virtual void OnEnter(State prevState) { }
//    }

//    /// <summary>����̃X�e�[�g�֑J�ڂł���悤�ɂ��邽�߂̉��z�X�e�[�g</summary>
//    public sealed class AnyState : State { }

//    public void AddTransition<TFrom, TTo>(int eventId) where TFrom : State, new()
//                                                       where TTo   : State, new()
//    {

//    }

//    public void AddAnyTransition<TTo>(int eventId) where TTo : State, new()
//    {
//        AddTransition<AnyState, TTo>(eventId);
//    }

//    public void Start<TFirst>() where TFirst : State, new()
//    {
//        Start()
//    }
//}
