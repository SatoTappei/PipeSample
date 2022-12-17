using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace Scroll
{
    /// <summary>
    /// Generatorコンポーネントから生成された具材
    /// </summary>
    public class FallItem : MonoBehaviour
    {
        static readonly string Tag = "Connect";

        [SerializeField] Rigidbody2D _rb;
        /// <summary>くっ付いた時に親子関係にする</summary>
        static Transform _parent;

        void Start()
        {
            // 最初の1回目の生成時だけくっ付いた時の親を検索してくる
            if(_parent == null)
            {
                _parent = GameObject.Find("Bar").transform;
            }

            this.OnCollisionEnter2DAsObservable()
                .Where(c => c.gameObject.CompareTag(Tag))
                .Subscribe(c => 
                {
                    // 物理演算を切る
                    _rb.isKinematic = true;
                    _rb.velocity = Vector3.zero;
                    _rb.angularVelocity = 0;

                    // z軸の回転を0に戻さないと歪む
                    Quaternion rot = transform.rotation;
                    rot.z = 0;
                    transform.rotation = rot;

                    transform.parent = _parent;

                    // どうにかする
                    // くっ付いたら一番高いところにいる奴を計算してカメラをフォーカスする
                    // くっ付いたらUIを更新する、スコア+n点
                    FindObjectOfType<CameraController>().SetFollow(c.transform);
                });
        }

        void Update()
        {

        }
    }
}
