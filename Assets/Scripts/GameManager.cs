using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �Q�[���}�l�[�W���[
/// </summary>
public class GameManager : MonoBehaviour
{
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
#endif
    }
}

/// <summary>
/// UnityEditor��ł̂݌Ăяo����f�o�b�O���O�̃N���X
/// </summary>
public static class Debug
{
    const string Symbol = "DEBUG_LOG_ON";

    [System.Diagnostics.Conditional(Symbol)]
    public static void Log(object message) => UnityEngine.Debug.Log(message);

    [System.Diagnostics.Conditional(Symbol)]
    public static void LogWarning(object message) => UnityEngine.Debug.LogWarning(message);

    [System.Diagnostics.Conditional(Symbol)]
    public static void LogError(object message) => UnityEngine.Debug.LogError(message);
}