using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace Scroll
{
    /// <summary>
    /// バーを動かすコントローラー
    /// </summary>
    public class BarController : MonoBehaviour
    {
        [SerializeField] Rigidbody2D _rb;
        [SerializeField] float _speed = 10;

        void Awake()
        {

        }

        void Start()
        {
            this.UpdateAsObservable()
                .Select(_ => new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0).normalized)
                .BatchFrame(0, FrameCountType.FixedUpdate)
                .Subscribe(v => _rb.velocity = v[0] * _speed);
        }
    }
}