using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stage3
{
    /// <summary>
    /// シーンで使用するサウンドを管理するコンポーネント
    /// サービスロケータ経由で呼び出す
    /// </summary>
    public class SoundManager : MonoBehaviour, ISoundService
    {
        void Awake()
        {
            Locator.Register<ISoundService>(this);
        }

        void OnDestroy()
        {
            Locator.UnRegister<ISoundService>(this);
        }

        public void Play(string key)
        {
            Debug.Log("音を再生:" + key);
        }
    }
}