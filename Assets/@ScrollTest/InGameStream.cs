using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Scroll
{
    /// <summary>
    /// ゲーム全体の流れを制御するマネージャー
    /// </summary>
    public class InGameStream : MonoBehaviour
    {
        [Header("バーの速度")]
        [SerializeField] int _barSpeed;
        [Header("具材が降ってくる間隔")]
        [SerializeField] int _itemGeneDist;
        [Header("制限時間")]
        [SerializeField] int _timeLimit;

        ReactiveProperty<float> _currentTime = new ReactiveProperty<float>();

        /// <summary>Presenterが値の変更を検知出来るように公開しておく</summary>
        public IReadOnlyReactiveProperty<float> CurrentTime => _currentTime;

        void Awake()
        {
            _currentTime.Value = _timeLimit;
        }

        void Start()
        {
            // 具材がくっ付いたらその具材をカメラがFollowする
            // 
        }

        void Update()
        {
            //Debug.Log(Time.realtimeSinceStartup);
            _currentTime.Value -= Time.deltaTime;
        }
    }
}
