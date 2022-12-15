using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// プレイヤーの移動を行うコンポーネント
/// </summary>
public class PlayerMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] Animator _anim;
    [SerializeField] int _speed = 10;

    Transform trans;
    /// <summary>入力を保持するベクトル</summary>
    Vector3 _moveInput;

    void Awake()
    {
        trans = transform;
    }

    void Start()
    {
        // 移動
        this.UpdateAsObservable()
            .Select(_ => _moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0).normalized)
            .BatchFrame(0, FrameCountType.FixedUpdate)
            .Subscribe(v => 
            {
                Vector3 vec = v[0] * _speed;
                vec.y = _rb.velocity.y;
                _rb.velocity = vec;
            });

        // 振り向きのアニメーション
        this.LateUpdateAsObservable()
            .Subscribe(_ => 
            {
                if (_moveInput.sqrMagnitude != 0)
                {
                    Vector3 scale = trans.localScale;
                    scale.x = _moveInput.x;
                    trans.localScale = scale;
                }

                _anim.SetFloat("speed", _moveInput.sqrMagnitude);
            });
    }
}
