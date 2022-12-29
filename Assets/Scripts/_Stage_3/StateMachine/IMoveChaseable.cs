using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stage3 
{
    /// <summary>
    /// プレイヤーを追従してくる敵の各ステート用インターフェース
    /// </summary>
    public interface IMoveChaseable
    {
        public GameObject Actor { get; set; }
        public Transform Target { get; set; }
        public Rigidbody2D Rb { get; set; }
    }
}
