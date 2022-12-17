using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scroll
{
    /// <summary>
    /// c‚èŠÔ‚ğ•\¦‚·‚éView
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
            /* ‰‰o‚ª‚ ‚ê‚Î‚±‚±‚É‘‚­ */

            _text.text = str;
        }
    }
}