using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Stage3
{
    /// <summary>
    /// サービスロケータ本体のクラス
    /// </summary>
    public static class Locator
    {
        /// <summary>登録するServiceの個数に応じて設定すること</summary>
        const int Capacity = 2;

        static readonly Dictionary<Type, object> _container;

        static Locator() => _container = new Dictionary<Type, object>(Capacity);

        /// <summary>T型のインスタンスを取得する</summary>
        public static T Resolve<T>() where T : class
        {
            if (_container.TryGetValue(typeof(T), out object value))
            {
                 return _container[typeof(T)] as T;
            }
            else
            {
                Debug.LogError("サービスが登録されていません: " + typeof(T));
                return null;
            }
        }

        /// <summary>T型のインスタンスを登録する、上書き可能</summary>
        public static void Register<T>(T instance) => _container[typeof(T)] = instance;

        /// <summary>T型のインスタンスが登録されていた場合は登録を解除する</summary>
        public static void UnRegister<T>(T instance)
        {
            if (_container.ContainsValue(instance))
                _container.Remove(typeof(T));
        }
    }
}
