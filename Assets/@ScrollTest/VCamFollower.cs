using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace Scroll
{
    /// <summary>
    /// VCam��Follow����I�u�W�F�N�g�𑀍삷��R���|�[�l���g
    /// </summary>
    public class VCamFollower : MonoBehaviour
    {
        [SerializeField] Vector3 _defaultPos;

        void Start()
        {
            transform.position = _defaultPos;
        }

        void Update()
        {

        }

        public void SetFollow(Transform target)
        {
            // ���݂��Ⴂ�ʒu�ł����t�����獂�����X�V���Ȃ�
            if (target.position.y < transform.position.y) return;

            Vector3 pos = transform.position;
            pos.y = target.position.y;

            transform.position = pos;
        }
    }
}