using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Scroll
{
    /// <summary>
    /// �Q�[���S�̗̂���𐧌䂷��}�l�[�W���[
    /// </summary>
    public class InGameStream : MonoBehaviour
    {
        [Header("�o�[�̑��x")]
        [SerializeField] int _barSpeed;
        [Header("��ނ��~���Ă���Ԋu")]
        [SerializeField] int _itemGeneDist;
        [Header("��������")]
        [SerializeField] int _timeLimit;

        ReactiveProperty<float> _currentTime = new ReactiveProperty<float>();

        /// <summary>Presenter���l�̕ύX�����m�o����悤�Ɍ��J���Ă���</summary>
        public IReadOnlyReactiveProperty<float> CurrentTime => _currentTime;

        void Awake()
        {
            _currentTime.Value = _timeLimit;
        }

        void Start()
        {
            // ��ނ������t�����炻�̋�ނ��J������Follow����
            // 
        }

        void Update()
        {
            //Debug.Log(Time.realtimeSinceStartup);
            _currentTime.Value -= Time.deltaTime;
        }
    }
}
