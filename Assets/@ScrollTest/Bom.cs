using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scroll
{
    /// <summary>
    /// ���e�̃R���|�[�l���g
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
                // GetComponent���Ă���̂ŗǂ��Ȃ�
                w.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
            }
        }
    }

}