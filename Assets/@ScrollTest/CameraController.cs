using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace Scroll
{
    /// <summary>
    /// �C�ӂ̃^�[�Q�b�g��Follow������J�����R���|�[�l���g
    /// </summary>
    public class CameraController : MonoBehaviour
    {
        [SerializeField] CinemachineVirtualCamera _cvc;

        void Start()
        {

        }

        void Update()
        {

        }

        public void SetFollow(Transform target)
        {
            _cvc.Follow = target;
        }
    }
}