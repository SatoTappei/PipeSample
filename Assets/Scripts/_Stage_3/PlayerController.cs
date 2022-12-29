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
            // テスト用にコライダーとリジボを止める
            GetComponent<CapsuleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().isKinematic = true;
        }

        void Update()
        {
            float hori = Input.GetAxis("Horizontal") * 0.5f;
            float vert = Input.GetAxis("Vertical") * 0.5f;

            Vector3 pos = transform.position;

            pos.x += hori;
            pos.y += vert;

            transform.position = pos;
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