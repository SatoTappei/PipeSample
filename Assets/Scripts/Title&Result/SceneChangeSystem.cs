using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// 指定したシーンを読み込む処理をボタンに割り当てるコンポーネント
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
