using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scroll
{
    /// <summary>
    /// 爆弾のコンポーネント
    /// </summary>
    public class Bom : MonoBehaviour
    {
        [SerializeField] LayerMask _mask;
        [SerializeField] Collider2D _col;

        void Start()
        {

        }

        void Update()
        {

        }

        public void Bomber()
        {
            _col.enabled = false;

            Collider2D[] v = Physics2D.OverlapCircleAll(transform.position, 1, _mask);
            foreach (var w in v)
            {
                // GetComponentしているので良くない
                w.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
            }
        }
    }

}