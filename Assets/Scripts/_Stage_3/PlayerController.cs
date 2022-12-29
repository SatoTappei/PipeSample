using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Stage3
{
    /// <summary>
    /// �v���C���[�𑀍삷��R���|�[�l���g
    /// </summary>
    public class PlayerController : MonoBehaviour, IPauseable
    {
        [Header("���݂̏�Ԃ�\������e�L�X�gUI")]
        [SerializeField] Text _statusView;

        void Start()
        {
            // �e�X�g�p�ɃR���C�_�[�ƃ��W�{���~�߂�
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
            // �|�[�Y���ɓ������~�߂�
        }

        public void Release()
        {
            // �|�[�Y�����œ����o��
        }
    }
}