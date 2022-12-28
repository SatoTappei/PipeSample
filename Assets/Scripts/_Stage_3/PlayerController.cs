using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Stage3
{
    /// <summary>
    /// プレイヤーを操作するコンポーネント
    /// </summary>
    public class PlayerController : MonoBehaviour, IPauseable
    {
        [Header("現在の状態を表示するテキストUI")]
        [SerializeField] Text _statusView;

        void Start()
        {

        }

        void Update()
        {

        }

        public void Pause()
        {
            // ポーズ時に動きを止める
        }

        public void Release()
        {
            // ポーズ解除で動き出す
        }
    }
}