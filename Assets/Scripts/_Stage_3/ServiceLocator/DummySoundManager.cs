using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stage3
{
    /// <summary>
    /// ダミーのSoundManagerコンポーネント
    /// サービスロケータ経由で呼び出す
    /// </summary>
    public class DummySoundManager : MonoBehaviour, ISoundService
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
            Debug.Log("ダミーの音再生処理:" + key);
        }
    }
}