using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stage3
{
    /// <summary>
    /// �V�[���Ŏg�p����T�E���h���Ǘ�����R���|�[�l���g
    /// �T�[�r�X���P�[�^�o�R�ŌĂяo��
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
            Debug.Log("�����Đ�:" + key);
        }
    }
}