using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace Scroll
{
    /// <summary>
    /// Generator�R���|�[�l���g���琶�����ꂽ���
    /// </summary>
    public class FallItem : MonoBehaviour
    {
        static readonly string Tag = "Connect";

        [SerializeField] Rigidbody2D _rb;
        /// <summary>�����t�������ɐe�q�֌W�ɂ���</summary>
        static Transform _parent;

        void Start()
        {
            // �ŏ���1��ڂ̐��������������t�������̐e���������Ă���
            if(_parent == null)
            {
                _parent = GameObject.Find("Bar").transform;
            }

            this.OnCollisionEnter2DAsObservable()
                .Where(c => c.gameObject.CompareTag(Tag))
                .Subscribe(c => 
                {
                    // �������Z��؂�
                    _rb.isKinematic = true;
                    _rb.velocity = Vector3.zero;
                    _rb.angularVelocity = 0;

                    // z���̉�]��0�ɖ߂��Ȃ��Ƙc��
                    Quaternion rot = transform.rotation;
                    rot.z = 0;
                    transform.rotation = rot;

                    transform.parent = _parent;

                    // �ǂ��ɂ�����
                    // �����t�������ԍ����Ƃ���ɂ���z���v�Z���ăJ�������t�H�[�J�X����
                    // �����t������UI���X�V����A�X�R�A+n�_
                    FindObjectOfType<CameraController>().SetFollow(c.transform);
                });
        }

        void Update()
        {

        }
    }
}
