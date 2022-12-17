using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Scroll
{
    /// <summary>
    /// Generatorコンポーネントから生成された具材
    /// </summary>
    public class FallItem : MonoBehaviour
    {
        static readonly string ConnectTag = "Connect";
        static readonly string BorderTag = "Border";

        [SerializeField] Rigidbody2D _rb;
        [SerializeField] UnityEvent _onCatched;

        /// <summary>くっ付いた時に親子関係にする</summary>
        static Transform _parent;
        /// <summary>くっ付いたときにカメラの位置を変更する</summary>
        static VCamFollower _follower;

        void Start()
        {
            // 最初の1回目の生成時だけ共通で使う参照を取ってくる
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
            // 削除ラインにぶつかった かつ くっ付いた状態ではない場合
            if (collision.gameObject.tag == BorderTag && transform.parent != _parent)
            {
                Destroy(gameObject);
            }
            // 具材または重箱にぶつかった場合
            else if (collision.gameObject.tag == ConnectTag)
            {
                // 物理演算を切る
                _rb.isKinematic = true;
                _rb.velocity = Vector3.zero;
                _rb.angularVelocity = 0;

                // z軸の回転を0に戻さないと歪む
                Quaternion rot = transform.rotation;
                rot.z = 0;
                transform.rotation = rot;

                // カメラを上に移動させる
                _follower.SetFollow(collision.transform);

                transform.parent = _parent;

                _onCatched?.Invoke();
            }
        }
    }
}
