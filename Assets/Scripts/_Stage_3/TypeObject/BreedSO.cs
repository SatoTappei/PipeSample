using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stage3
{
    /// <summary>
    /// 型オブジェクトで実装する敵の系統を表すSO
    /// </summary>
    [CreateAssetMenu(menuName = "Stage_3/BreedSO")]
    public class BreedSO : ScriptableObject
    {
        [Header("親系統")]
        [SerializeField] BreedSO _parent;
        [Header("この系統の属性")]
        [SerializeField] string _attribute;

        /// <summary>親系統がある場合は再帰的に親のTypeプロパティを呼び出す</summary>
        public string Attribute { get => _attribute ?? _parent.Attribute; }
    }
}
