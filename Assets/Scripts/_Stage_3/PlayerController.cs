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

        }

        void Update()
        {

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