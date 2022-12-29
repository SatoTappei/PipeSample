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
        /// <summary>ステートの合計数、遷移先を格納する辞書型の初期容量に使う</summary>
        readonly int Total;

        State _currentState;
        /// <summary>どのステートからでも出来る遷移の起点となるステート</summary>
        State _anyState;

        public StateMachine(int total)
        {
            Total = total;
            _anyState = new AnyState();
            _anyState.Dic = new Dictionary<int, State>(Total);
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

        /// <summary>渡された型のステートのインスタンスを生成して返す</summary>
        public T Instantiate<T>(params Object[] objs) where T : State, new()
        {
            T state = new T();

            // コンストラクタが使えないのでプロパティとメソッドを使用してフィールドに代入
            state.Dic = new Dictionary<int, State>(Total);
            state.StateMachine = this;
            state.SetField(objs);

            return state;
        }

        /// <summary>遷移を追加する</summary>
        public void AddTransition(int id, State from, State to) => from.AddState(id, to);

        /// <summary>どのステートからでも出来る遷移を追加する</summary>
        public void AddAnyTransition(int id, State to) => _anyState.AddState(id, to);

        /// <summary>指定したIDのステートに遷移する</summary>
        public void Transition(int id) => Transition(_currentState, id);

        /// <summary>指定したIDのステートに、どのステートからでも出来る遷移を行う</summary>
        public void AnyTransition(int id) => Transition(_anyState, id);

        /// <summary>次のステートに遷移する際の処理</summary>
        void Transition(State state, int id)
        {
            _currentState.OnExit();
            _currentState = state.GetState(id);
            _currentState.OnEnter();
        }

        /// <summary>
        /// 各ステートの抽象クラス
        /// </summary>
        public abstract class State
        {
            /// <summary>このステートの遷移先を保存する辞書型</summary>
            Dictionary<int, State> _dic;
            /// <summary>このステートが登録されているステートマシン</summary>
            StateMachine _stateMachine;

            // 1度代入したら再代入できないプロパティ
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

            /// <summary>遷移先のステートを追加する</summary>
            public void AddState(int id, State state) => Dic[id] = state;

            /// <summary>遷移先のステートを取得する</summary>
            public State GetState(int id)
            {
                if (Dic.TryGetValue(id, out State value))
                {
                    return value;
                }
                else
                {
                    Debug.LogError("対応するステートがありません: " + id);
                    return null;
                }
            }

            /// <summary>引数ありコンストラクタが使えないのでメソッドでフィールドへの参照を渡す</summary>
            /// <param name="objs">現在の体力など、値型には対応していない</param>
            public abstract void SetField(params Object[] objs);
            
            public abstract void OnEnter();
            public abstract void OnUpdate();
            public abstract void OnExit();
        }

        /// <summary>
        /// どのステートからでも遷移できる遷移に使うステート
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
