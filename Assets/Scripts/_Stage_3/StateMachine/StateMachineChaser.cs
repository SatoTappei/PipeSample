using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stage3
{
    /// <summary>
    /// プレイヤーを見つけると追いかけてくる敵のステートマシン
    /// </summary>
    public class StateMachineChaser : MonoBehaviour, IPauseable
    {
        enum Event
        {
            Idle,
            Wander,
            Chase,
            Jump,
        }

        void Start()
        {

        }

        void Update()
        {

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