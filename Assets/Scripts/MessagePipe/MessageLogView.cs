using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// アイテムを取得した場合に表示されるログのUI:View
/// </summary>
public class MessageLogView : MonoBehaviour
{
    [SerializeField] Text _text;

    void Awake()
    {
        _text.text = "";
    }

    void Start()
    {

    }

    public void Print(string str)
    {
        _text.text = str;
    }
}
