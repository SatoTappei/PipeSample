using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stage3
{
    /// <summary>
    /// �_�~�[��SoundManager�R���|�[�l���g
    /// �T�[�r�X���P�[�^�o�R�ŌĂяo��
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
            Debug.Log("�_�~�[�̉��Đ�����:" + key);
        }
    }
}