using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Scroll
{
    /// <summary>
    /// 残り時間をタイマーに表示するPresenter
    /// </summary>
    public class TimerPresenter : MonoBehaviour
    {
        [SerializeField] InGameStream _inGameStream;
        [SerializeField] TimerView _view;

        void Start()
        {
            _inGameStream.CurrentTime.Subscribe(f =>
            {
                _view.SetValue(f.ToString("##"));
            }).AddTo(this);
        }

        void Update()
        {

        }
    }
}
