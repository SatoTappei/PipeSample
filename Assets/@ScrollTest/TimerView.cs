using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scroll
{
    /// <summary>
    /// �c�莞�Ԃ�\������View
    /// </summary>
    public class TimerView : MonoBehaviour
    {
        [SerializeField] Text _text;

        void Start()
        {

        }

        void Update()
        {

        }
       
        public void SetValue(string str)
        {
            /* ���o������΂����ɏ��� */

            _text.text = str;
        }
    }
}