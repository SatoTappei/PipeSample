using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stage3
{
    /// <summary>
    /// プレイヤーを見つけると落下する敵のステートマシン
    /// </summary>
    public class StateMachineFaller : MonoBehaviour, IPauseable
    {
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