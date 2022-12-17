using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scroll
{
    /// <summary>
    /// 残り時間を表示するView
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
            /* 演出があればここに書く */

            _text.text = str;
        }
    }
}