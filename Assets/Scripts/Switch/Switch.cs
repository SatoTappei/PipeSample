using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// �X�C�b�`�𐧌䂷��R���|�[�l���g
/// ��ɉ���������Ă���Ԃ�On�A��������Ă��Ȃ�����Off�ɂȂ�
/// </summary>
public class Switch : MonoBehaviour
{
    [SerializeField] BoxCollider2D _col;
    [SerializeField] SpriteRenderer _sr;
    [SerializeField] Sprite _defaultSprite;
    [SerializeField] Sprite _pushedSprite;

    [Header("ISwitchable�����������R���|�[�l���g")]
    [SerializeField] GameObject _gimmick;

    /// <summary>�X�C�b�`�̏�ɏ���Ă���I�u�W�F�N�g��</summary>
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
