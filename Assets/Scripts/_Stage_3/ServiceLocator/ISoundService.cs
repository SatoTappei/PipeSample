using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stage3
{
    /// <summary>
    /// サービスロケータに登録するのに使う、サウンドのインターフェース
    /// </summary>
    public interface ISoundService
    {
        public void Play(string key);
    }
}