using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stage3
{
    /// <summary>
    /// ポーズに対応するインターフェース
    /// </summary>
    public interface IPauseable
    {
        public void Pause();
        public void Release();
    }
}
