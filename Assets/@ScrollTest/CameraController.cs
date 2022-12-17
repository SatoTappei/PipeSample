using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace Scroll
{
    /// <summary>
    /// 任意のターゲットをFollowさせるカメラコンポーネント
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