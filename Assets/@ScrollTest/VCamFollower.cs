using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace Scroll
{
    /// <summary>
    /// VCamがFollowするオブジェクトを操作するコンポーネント
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
            // 現在より低い位置でくっ付いたら高さを更新しない
            if (target.position.y < transform.position.y) return;

            Vector3 pos = transform.position;
            pos.y = target.position.y;

            transform.position = pos;
        }
    }
}