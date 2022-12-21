using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �A�C�e�����擾�����ꍇ�ɕ\������郍�O��UI:View
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
