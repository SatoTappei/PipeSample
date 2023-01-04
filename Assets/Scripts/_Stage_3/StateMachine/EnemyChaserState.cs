using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stage3
{
    using State = StateMachine.State;

    /// <summary>
    /// EnemyChaserクラスからStateの記述の部分だけ分割
    /// </summary>
    public partial class EnemyChaser : MonoBehaviour
    {
        /// <summary>
        /// アイドル状態のステート
        /// </summary>
        class StateIdle : State, IMoveChaseable, IPauseable
        {
            public GameObject Actor { get; set; }
            public Transform Target { get; set; }
            public Rigidbody2D Rb { get; set; }

            readonly float Range = 15f;
            /// <summary>うろうろ状態に遷移する確率</summary>
            readonly int Prob = 2;

            public override void SetField(params Object[] objs)
            {
                Actor = objs[0] as GameObject;
                Target = objs[1] as Transform;
                Rb = objs[2] as Rigidbody2D;
            }

            public override void OnEnter()
            {

            }

            public override void OnUpdate()
            {
                // プレイヤーとの距離が一定以下なら追跡状態に遷移する
                if ((Target.position - Actor.transform.position).sqrMagnitude < Range)
                {
                    StateMachine.Transition((int)StateID.Chase);
                    return;
                }

                // 確率でうろうろ状態に遷移する
                if (Random.Range(0, 100) < Prob)
                {
                    StateMachine.Transition((int)StateID.Wander);
                    return;
                }
            }

            public override void OnExit()
            {

            }

            public void Pause()
            {
                Debug.Log("ポーズ");
            }

            public void Release()
            {
            }
        }

        /// <summary>
        /// うろうろ状態のステート
        /// </summary>
        class StateWander : State, IMoveChaseable, IPauseable
        {
            public GameObject Actor { get; set; }
            public Transform Target { get; set; }
            public Rigidbody2D Rb { get; set; }

            int _dir;
            float _time;

            public override void SetField(params Object[] objs)
            {
                Actor = objs[0] as GameObject;
                Target = objs[1] as Transform;
                Rb = objs[2] as Rigidbody2D;
            }

            public override void OnEnter()
            {
                // 左右どちらかにランダムな移動時間だけ移動する
                _dir = (int)Mathf.Sign(Random.Range(-10, 11));
                _time = Random.Range(0.5f, 1.5f);
                // 移動が終わったらアイドル状態に遷移する
                // 足場が無くなったらジャンプステートに遷移する
            }

            public override void OnUpdate()
            {
                // うろうろが終わったらアイドル状態に遷移する
                // 段差を見つけたらジャンプをする

            }

            public override void OnExit()
            {

            }

            public void Pause()
            {
            }

            public void Release()
            {
            }
        }

        /// <summary>
        /// プレイヤーを追跡している状態のステート
        /// </summary>
        class StateChase : State, IMoveChaseable, IPauseable
        {
            public GameObject Actor { get; set; }
            public Transform Target { get; set; }
            public Rigidbody2D Rb { get; set; }

            readonly float Range = 5f;
            readonly float Speed = 1;

            public override void SetField(params Object[] objs)
            {
                Actor = objs[0] as GameObject;
                Target = objs[1] as Transform;
                Rb = objs[2] as Rigidbody2D;
            }

            public override void OnEnter()
            {

            }

            public override void OnUpdate()
            {
                // プレイヤーとの距離が一定以上離れていたらアイドル状態に遷移する
                if ((Target.position - Actor.transform.position).sqrMagnitude > Range)
                {
                    StateMachine.Transition((int)StateID.Idle);
                    return;
                }

                // プレイヤーの方向に応じて右左に移動する
                float dir = Mathf.Sign(Target.position.x - Actor.transform.position.x);
                Rb.velocity = Vector2.right * dir * Speed;
            }

            public override void OnExit()
            {

            }

            public void Pause()
            {
            }

            public void Release()
            {
            }
        }

        /// <summary>
        /// ジャンプしている状態のステート
        /// </summary>
        class StateJump : State, IMoveChaseable, IPauseable
        {
            public GameObject Actor { get; set; }
            public Transform Target { get; set; }
            public Rigidbody2D Rb { get; set; }

            public override void SetField(params Object[] objs)
            {
                Actor = objs[0] as GameObject;
                Target = objs[1] as Transform;
                Rb = objs[2] as Rigidbody2D;
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

            public void Pause()
            {
                //Debug.Log("ポーズ");
            }

            public void Release()
            {
                //Debug.Log("ポーズ解除");
            }
        }

        /// <summary>
        /// これ以上動かさない場合に遷移されるステート
        /// </summary>
        class StateEnd : State
        {
            public override void SetField(params Object[] objs) { }

            public override void OnEnter()
            {
                Debug.Log("死亡");
            }

            public override void OnUpdate() { }
            public override void OnExit() { }
        }
    }
}
