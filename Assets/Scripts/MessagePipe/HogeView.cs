using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 専用のエントリーポイントから必要なオブジェクトが注入される
/// MVPパターンのView
/// </summary>
public class HogeView : MonoBehaviour
{
    [SerializeField] Button _button;

    public Button Button { get => _button; }
}
