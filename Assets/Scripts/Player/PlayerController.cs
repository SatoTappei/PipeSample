using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// プレイヤーの操作を行うコンポーネント
/// </summary>
public class PlayerController : MonoBehaviour
{
    readonly int JumpPower = 20;

    [SerializeField] Rigidbody2D _rb;
    [SerializeField] Animator _anim;
    [SerializeField] Collider2D _jumpCol;
    [SerializeField] LayerMask _mask;
    [SerializeField] int _speed = 10;

    Transform _trans;
    /// <summary>攻撃状態を表すフラグ</summary>
    bool _onAttack;
    /// <summary>入力を保持するベクトル</summary>
    Vector3 _moveInput;

    void Awake()
    {
        _trans = transform;
    }

    void Start()
    {
        // 移動(Whereオペレータが攻撃のフラグに依存しているので分離出来ない)
        this.UpdateAsObservable()
            .Where(_=> !_onAttack)
            .Select(_ => _moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0).normalized)
            .BatchFrame(0, FrameCountType.FixedUpdate)
            .Subscribe(v => 
            {
                Vector3 vec = v[0] * _speed;
                vec.y = _rb.velocity.y;
                _rb.velocity = vec;
            }).AddTo(this);

        // ジャンプ
        this.UpdateAsObservable()
            .Where(_ => Input.GetKeyDown(KeyCode.X) && _jumpCol.IsTouchingLayers(_mask))
            .BatchFrame(0, FrameCountType.FixedUpdate)
            .Subscribe(_ =>
            {
                _rb.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            }).AddTo(this);

        // 攻撃
        ObservableStateMachineTrigger trigger = _anim.GetBehaviour<ObservableStateMachineTrigger>();
        trigger.OnStateEnterAsObservable()
               .Where(x => x.StateInfo.IsName("Attack"))
               .Subscribe(_ => 
               { 
                   _onAttack = true; 
               }).AddTo(this);
        
        trigger.OnStateExitAsObservable()
               .Where(x => x.StateInfo.IsName("Attack"))
               .Subscribe(_ => 
               {
                   _onAttack = false;
               }).AddTo(this);

        this.UpdateAsObservable()
            .Where(_ => Input.GetKeyDown(KeyCode.Z) && !_onAttack)
            .Subscribe(_ => 
            {
                _anim.Play("Attack");
            }).AddTo(this);

        // 振り向きのアニメーション
        this.UpdateAsObservable()
            .Subscribe(_ =>
            {
                if (_moveInput.sqrMagnitude != 0)
                {
                    Vector3 scale = _trans.localScale;
                    scale.x = _moveInput.x;
                    _trans.localScale = scale;
                }

                _anim.SetFloat("speed", _moveInput.sqrMagnitude);
            }).AddTo(this);
    }
}
