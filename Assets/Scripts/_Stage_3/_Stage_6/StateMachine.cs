//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

///// <summary>
///// 汎用的ステートマシン
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

//    /// <summary>ステートを表すクラス</summary>
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

//    /// <summary>特定のステートへ遷移できるようにするための仮想ステート</summary>
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
