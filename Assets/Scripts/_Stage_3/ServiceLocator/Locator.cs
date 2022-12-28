using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Stage3
{
    /// <summary>
    /// �T�[�r�X���P�[�^�{�̂̃N���X
    /// </summary>
    public static class Locator
    {
        /// <summary>�o�^����Service�̌��ɉ����Đݒ肷�邱��</summary>
        const int Capacity = 2;

        static readonly Dictionary<Type, object> _container;

        static Locator() => _container = new Dictionary<Type, object>(Capacity);

        /// <summary>T�^�̃C���X�^���X���擾����</summary>
        public static T Resolve<T>() where T : class
        {
            if (_container.TryGetValue(typeof(T), out object value))
            {
                 return _container[typeof(T)] as T;
            }
            else
            {
                Debug.LogError("�T�[�r�X���o�^����Ă��܂���: " + typeof(T));
                return null;
            }
        }

        /// <summary>T�^�̃C���X�^���X��o�^����A�㏑���\</summary>
        public static void Register<T>(T instance) => _container[typeof(T)] = instance;

        /// <summary>T�^�̃C���X�^���X���o�^����Ă����ꍇ�͓o�^����������</summary>
        public static void UnRegister<T>(T instance)
        {
            if (_container.ContainsValue(instance))
                _container.Remove(typeof(T));
        }
    }
}
