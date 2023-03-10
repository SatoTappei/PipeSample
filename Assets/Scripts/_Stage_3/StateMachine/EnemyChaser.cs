using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stage3
{
    /// <summary>
    /// プレイヤーを見つけると追いかけてくる敵のコンポーネント
    /// 各StateはEnemyChaserState.csに分割
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

        [Header("各ステートに渡す参照")]
        [SerializeField] Transform _target;
        [SerializeField] Rigidbody2D _rb;

        /// <summary>ステートマシンの操作は使う側で行う</summary>
        StateMachine _stateMachine;
        /// <summary>各ステートのポーズ処理を配列に格納して一気に呼ぶ</summary>
        IPauseable[] _states;

        // テスト:検証用の仮の死亡フラグ、検証が終わったら消す
        bool _isDead;

        void Start()
        {
            // 現在の課題
            // 1.IMoveChaseableを継承したステートが同じフィールドを持っているので
            //   共通部分を抜き出せないか
            // 2.AnyStateの遷移条件をこっちのUpdate内に書いているのでなんか汚い
            // 3.各ステートにポーズ機能の実装

            _stateMachine = new StateMachine(5);
            //_states = new IPauseable[5];

            // 各ステートのインスタンスを生成する
            StateIdle idle     = _stateMachine.Instantiate<StateIdle>  (gameObject, _target, _rb);
            StateWander wander = _stateMachine.Instantiate<StateWander>(gameObject, _target, _rb);
            StateChase chase   = _stateMachine.Instantiate<StateChase> (gameObject, _target, _rb);
            StateJump jump     = _stateMachine.Instantiate<StateJump>  (gameObject, _target, _rb);
            StateEnd end       = _stateMachine.Instantiate<StateEnd>   ();

            _states = new IPauseable[]
            {
                idle,
                wander,
                chase,
                jump,
            };

            // アイドル状態から うろうろ 追跡 状態に遷移できる
            _stateMachine.AddTransition((int)StateID.Wander, idle, wander);
            _stateMachine.AddTransition((int)StateID.Chase, idle, chase);
            // 追跡状態のときにプレイヤーと一定以上距離が離れるとアイドル状態に遷移する
            _stateMachine.AddTransition((int)StateID.Idle, chase, idle);
            // うろうろ 追跡 状態のときは段差があるとジャンプする
            _stateMachine.AddTransition((int)StateID.Jump, wander, jump);
            _stateMachine.AddTransition((int)StateID.Jump, chase, jump);
            // ジャンプ後はアイドル状態に戻る
            // うろうろしていた場合は止まる、追跡していた場合は追跡再開
            _stateMachine.AddTransition((int)StateID.Idle, jump, idle);

            // どの状態でも死亡した場合は死亡状態に遷移する
            _stateMachine.AddAnyTransition((int)StateID.End, end);

            _stateMachine.Start(idle);
        }

        void Update()
        {
            // テスト用、全員の死亡フラグを立てる
            if (Input.GetKeyDown(KeyCode.Q) && !_isDead)
            {
                _isDead = true;
            }
            // 以下二つテスト用、ポーズ処理
            if (Input.GetKeyDown(KeyCode.P))
            {
                Pause();
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                Release();
            }
        }

        void FixedUpdate()
        {
            // 死んでいないかチェック
            if (_isDead)
            {
                _stateMachine.AnyTransition((int)StateID.End);
                //_stateMachine.AnyTransition((int)StateID.End, end);
            }

            // リジボを使って移動させているのでこっちで呼んでいる
            // が、Update()で呼ぶ処理と分けたい
            _stateMachine.Update();
        }

        public void Pause()
        {
            foreach (IPauseable state in _states)
                state.Pause();
        }

        public void Release()
        {
            foreach (IPauseable state in _states)
                state.Release();
        }
    }
}