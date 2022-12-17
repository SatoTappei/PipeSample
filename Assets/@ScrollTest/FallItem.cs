using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Scroll
{
    /// <summary>
    /// Generator�R���|�[�l���g���琶�����ꂽ���
    /// </summary>
    public class FallItem : MonoBehaviour
    {
        static readonly string ConnectTag = "Connect";
        static readonly string BorderTag = "Border";

        [SerializeField] Rigidbody2D _rb;
        [SerializeField] UnityEvent _onCatched;

        /// <summary>�����t�������ɐe�q�֌W�ɂ���</summary>
        static Transform _parent;
        /// <summary>�����t�����Ƃ��ɃJ�����̈ʒu��ύX����</summary>
        static VCamFollower _follower;

        void Start()
        {
            // �ŏ���1��ڂ̐������������ʂŎg���Q�Ƃ�����Ă���
            if(_parent == null)
            {
                _parent = GameObject.Find("Bar").transform;
                _follower = FindObjectOfType<VCamFollower>();
            }
        }

        void Update()
        {

        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            // �폜���C���ɂԂ����� ���� �����t������Ԃł͂Ȃ��ꍇ
            if (collision.gameObject.tag == BorderTag && transform.parent != _parent)
            {
                Destroy(gameObject);
            }
            // ��ނ܂��͏d���ɂԂ������ꍇ
            else if (collision.gameObject.tag == ConnectTag)
            {
                // �������Z��؂�
                _rb.isKinematic = true;
                _rb.velocity = Vector3.zero;
                _rb.angularVelocity = 0;

                // z���̉�]��0�ɖ߂��Ȃ��Ƙc��
                Quaternion rot = transform.rotation;
                rot.z = 0;
                transform.rotation = rot;

                // �J��������Ɉړ�������
                _follower.SetFollow(collision.transform);

                transform.parent = _parent;

                _onCatched?.Invoke();
            }
        }
    }
}
