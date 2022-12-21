using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// �w�肵���V�[����ǂݍ��ޏ������{�^���Ɋ��蓖�Ă�R���|�[�l���g
/// </summary>
public class SceneChangeSystem : MonoBehaviour
{
    [SerializeField] string _name;

    void Awake()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(_name);
        });
    }
}
