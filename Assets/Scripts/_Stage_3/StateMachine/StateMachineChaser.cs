using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stage3
{
    /// <summary>
    /// �v���C���[��������ƒǂ������Ă���G�̃X�e�[�g�}�V��
    /// </summary>
    public class StateMachineChaser : MonoBehaviour, IPauseable
    {
        enum Event
        {
            Idle,
            Wander,
            Chase,
            Jump,
        }

        void Start()
        {

        }

        void Update()
        {

        }

        public void Pause()
        {
            // �|�[�Y���̏���
        }

        public void Release()
        {
            // �|�[�Y�������̏���
        }
    }
}