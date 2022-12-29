using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stage3
{
    using State = StateMachine.State;
    
    /// <summary>
    /// プレイヤーを見つけると追いかけてくる敵のコンポーネント
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
        /// アイドル状態のステート
        /// </summary>
        class StateIdle : State, IMoveChaseable
        {
            public GameObject Actor { get; set; }
            public Transform Target { get; set; }
            public Rigidbody2D Rb { get; set; }

            /// <summary>ターゲットとの距離がこれ以下になると追跡状態に遷移する</summary>
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
                // 確率でうろうろ状態に遷移する

                // プレイヤーを見つけたら追跡状態に遷移する
                if (Vector3.Distance(Actor.transform.position, Target.position) < Range)
                {
                    Debug.Log("遷移");
                    _stateMachine.Transition((int)StateID.Chase);
                }
            }

            public override void OnExit()
            {
                Debug.Log("アイドル状態から抜ける");
            }
        }

        /// <summary>
        /// うろうろ状態のステート
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
                // うろうろが終わったらアイドル状態に遷移する
                // 段差を見つけたらジャンプをする
            }

            public override void OnExit()
            {

            }
        }

        /// <summary>
        /// プレイヤーを追跡している状態のステート
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
                Debug.Log("追跡状態に入る");
            }

            public override void OnUpdate()
            {
                Debug.Log("追跡中");
            }

            public override void OnExit()
            {

            }
        }

        /// <summary>
        /// ジャンプしている状態のステート
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
                // ジャンプ後はアイドル状態に遷移する
            }

            public override void OnExit()
            {

            }
        }

        /// <summary>
        /// これ以上動かさない場合に遷移されるステート
        /// </summary>
        class StateEnd : State
        {
            public StateEnd(int capacity, StateMachine stateMachine) : base(capacity, stateMachine) { }

            public override void OnEnter()
            {
                // 破棄するなりenabledするなり
            }

            public override void OnUpdate() { }
            public override void OnExit() { }
        }

        [Header("各ステートに渡す参照")]
        [SerializeField] Transform _target;
        [SerializeField] Rigidbody2D _rb;

        /// <summary>ステートマシンの操作は使う側で行う</summary>
        StateMachine _stateMachine;

        void Start()
        {
            _stateMachine = new StateMachine(4);

            // インスタンスをこっちで生成して渡す
            var idle = new StateIdle(2, _stateMachine, gameObject, _target, _rb);
            var wander = new StateWander(1, _stateMachine, gameObject, _target, _rb);
            var chase = new StateChase(1, _stateMachine, gameObject, _target, _rb);
            var jump = new StateJump(1, _stateMachine, gameObject, _target, _rb);
            
            // アイドル状態から うろうろ 追跡 状態に遷移できる
            _stateMachine.AddTransition(idle, wander, (int)StateID.Wander);
            _stateMachine.AddTransition(idle, chase, (int)StateID.Chase);
            // うろうろ 追跡 状態のときは段差があるとジャンプする
            _stateMachine.AddTransition(wander, jump, (int)StateID.Jump);
            _stateMachine.AddTransition(chase, jump, (int)StateID.Jump);
            // ジャンプ後はアイドル状態に戻る
            // うろうろしていた場合は止まる、追跡していた場合は追跡再開
            _stateMachine.AddTransition(jump, idle, (int)StateID.Idle);

            _stateMachine.Start(idle);

            // アイドル状態から うろうろ 追跡 状態に遷移できる
            //_stateMachine.AddTransition<StateIdle, StateWander>((int)Event.Wander);
            //_stateMachine.AddTransition<StateIdle, StateChase>((int)Event.Chase);
            // うろうろ 追跡 状態のときは段差があるとジャンプする
            //_stateMachine.AddTransition<StateWander, StateJump>((int)Event.Jump);
            //_stateMachine.AddTransition<StateChase, StateJump>((int)Event.Jump);
            // ジャンプ後はアイドル状態に戻る
            // うろうろしていた場合は止まる、追跡していた場合は追跡再開
            //_stateMachine.AddTransition<StateJump, StateIdle>((int)Event.Idle);

            // おしまい
            //_stateMachine.AddAnyTransition<StateEnd>((int)Event.End);

            // 任意のステートから始める
            //_stateMachine.Start<StateIdle>();
        }

        void FixedUpdate()
        {
            // リジボを使って移動させているのでこっちで呼んでいる
            // が、Update()で呼ぶ処理と分けたい
            _stateMachine.Update();
        }

        public void Pause()
        {
            // ポーズ時の処理
        }

        public void Release()
        {
            // ポーズ解除時の処理
        }
    }
}