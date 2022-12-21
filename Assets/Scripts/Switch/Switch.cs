using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// スイッチを制御するコンポーネント
/// 上に何かが乗っている間はOn、何も乗っていない時はOffになる
/// </summary>
public class Switch : MonoBehaviour
{
    [SerializeField] BoxCollider2D _col;
    [SerializeField] SpriteRenderer _sr;
    [SerializeField] Sprite _defaultSprite;
    [SerializeField] Sprite _pushedSprite;

    [Header("ISwitchableを実装したコンポーネント")]
    [SerializeField] GameObject _gimmick;

    /// <summary>スイッチの上に乗っているオブジェクト数</summary>
    int _count;

    void Start()
    {
        ISwitchable switchable = _gimmick.GetComponent<ISwitchable>();

        this.OnTriggerEnter2DAsObservable()
            .Where(c => c.gameObject.CompareTag("Switchable"))
            .Subscribe(_ =>
            {
                _count++;

                _sr.sprite = _pushedSprite;
                switchable.OnSwitchOn();
            });

        this.OnTriggerExit2DAsObservable()
            .Where(c => c.gameObject.CompareTag("Switchable"))
            .Subscribe(_ =>
            {
                _count = Mathf.Max(0, --_count);

                if (_count == 0)
                {
                    _sr.sprite = _defaultSprite;
                    switchable.OnSwitchOff();
                }
            });
    }

    void Update()
    {

    }
}
