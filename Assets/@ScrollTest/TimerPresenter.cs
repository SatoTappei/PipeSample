using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Scroll
{
    /// <summary>
    /// �c�莞�Ԃ��^�C�}�[�ɕ\������Presenter
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
