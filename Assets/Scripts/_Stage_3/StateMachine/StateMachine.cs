using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stage3
{
    /// <summary>
    /// 汎用的なステートマシン
    /// </summary>
    public class StateMachine
    {
        /// <summary>現在のステート</summary>
        State _currentState;
        /// <summary>このステートマシンに登録するステートのセット</summary>
        //HashSet<State> _stateSet;

        public StateMachine(int capacity)
        {
            //_stateSet = new HashSet<State>(capacity);
        }

        /// <summary>ステートを指定して始める</summary>
        public void Start(State state)
        {
            _currentState = state;
            _currentState.OnEnter();
        }

        /// <summary>現在のステートを更新する</summary>
        public void Update()
        {
            _currentState.OnUpdate();
        }

        ///// <summary>遷移を追加する</summary>
        //public void AddTransition<TFrom, TTo>(int id) where TFrom : State
        //                                              where TTo   : State
        //{
        //    // 未使用
        //}

        /// <summary>遷移を追加する</summary>
        public void AddTransition(State from, State to, int id)
        {
            // このステートマシンで使用するステートとして追加する
            //_stateSet.Add(from);
            //_stateSet.Add(to);

            // from の移動先のステートとして to を登録する
            from.AddState(id, to);
        }

        ///// <summary>どのステートからでも遷移できる遷移を追加する</summary>
        //public void AddAnyTransition<TTo>(int id) where TTo : State
        //{
        //    // 未使用
        //}

        /// <summary>指定したIDのステートに遷移する</summary>
        public void Transition(int id)
        {
            _currentState.OnExit();
            _currentState = _currentState.GetState(id);
            _currentState.OnEnter();
        }

        /// <summary>
        /// 各ステートの抽象クラス
        /// </summary>
        public abstract class State
        {
            /// <summary>辞書型の初期容量、超えないように設定する</summary>
            readonly int _capacity;
            /// <summary>このステートの遷移先を保存する辞書型</summary>
            Dictionary<int, State> _dic;
            /// <summary>このステートが登録されているステートマシン</summary>
            protected StateMachine _stateMachine;

            public State(int capacity, StateMachine stateMachine)
            {
                _capacity = capacity;
                _dic = new Dictionary<int, State>(capacity);
                _stateMachine = stateMachine;
            }

            /// <summary>遷移先のステートを追加する</summary>
            public void AddState(int id, State state)
            {
                if (_dic.Count == _capacity)
                    Debug.LogWarning("ステート数が初期容量をオーバーしました: " + this);

                 _dic[id] = state;
            }

            /// <summary>遷移先のステートを取得する</summary>
            public State GetState(int id)
            {
                if (_dic.TryGetValue(id, out State value))
                {
                    return value;
                }
                else
                {
                    Debug.LogError("対応するステートがありません: " + id);
                    return null;
                }
            }

            public abstract void OnEnter();
            public abstract void OnUpdate();
            public abstract void OnExit();
        }

        /// <summary>
        /// どのステートからでも遷移できる遷移に使うステート
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
