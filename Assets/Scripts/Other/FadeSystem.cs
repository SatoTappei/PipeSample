using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

/// <summary>
/// �V�[���J�ڎ��Ƀt�F�[�h������
/// </summary>
public class FadeSystem : MonoBehaviour
{
    public static FadeSystem _instance;

    [SerializeField] RawImage _img;
    [Header("�t�F�[�h�ɂ����鎞��")]
    [SerializeField] float _time;

    bool _isFading;
    /// <summary>�t�F�[�h�����ǂ���</summary>
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
    /// DotWeen���g�p�����t�F�[�h�A�E�g
    /// </summary>
    /// <param name="scene">���̃V�[����</param>
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
