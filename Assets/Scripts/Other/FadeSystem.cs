using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

/// <summary>
/// シーン遷移時にフェードさせる
/// </summary>
public class FadeSystem : MonoBehaviour
{
    public static FadeSystem _instance;

    [SerializeField] RawImage _img;
    [Header("フェードにかかる時間")]
    [SerializeField] float _time;

    bool _isFading;
    /// <summary>フェード中かどうか</summary>
    public bool IsFading { get => _isFading; }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);

            SceneManager.activeSceneChanged += FadeIn;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void FadeIn(Scene _, Scene __)
    {
        _img.DOFade(0, _time)
            .OnStart(() => 
            {
                _isFading = true;
            })
            .OnComplete(() => 
            {
                _isFading = false;
                _img.enabled = false;
            });
    }

    /// <summary>
    /// DotWeenを使用したフェードアウト
    /// </summary>
    /// <param name="scene">次のシーン名</param>
    public void FadeOut(string scene)
    {
        _img.DOFade(1, _time)
            .OnStart(() =>
            {
                _isFading = true;
                _img.enabled = true;
            })
            .OnComplete(() =>
            {
                _isFading = false;

                SceneManager.LoadScene(scene);
            });
    }
}
