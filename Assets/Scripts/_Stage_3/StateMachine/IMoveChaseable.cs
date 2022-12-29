using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stage3 
{
    /// <summary>
    /// �v���C���[��Ǐ]���Ă���G�̊e�X�e�[�g�p�C���^�[�t�F�[�X
    /// </summary>
    public interface IMoveChaseable
    {
        public GameObject Actor { get; set; }
        public Transform Target { get; set; }
        public Rigidbody2D Rb { get; set; }
    }
}
