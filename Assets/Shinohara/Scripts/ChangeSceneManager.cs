using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// シーン遷移を管理するスクリプト
/// </summary>
public class ChangeSceneManager : MonoBehaviour
{
    /// <summary>フェードUI</summary>
    [SerializeField] GameObject _fadeUI;
    /// <summary>説明用UI</summary>
    [SerializeField] GameObject _explanationUI;
    /// <summary>ゲームプレイ中のBGM</summary>
    [SerializeField] AudioSource _bgm;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    /// <summary>フェード用UIを生成する</summary>
    public void SetFadeUI()
    {
        Instantiate(_fadeUI);
        _bgm.enabled = false;
    }

    /// <summary>
    /// シーン遷移をする
    /// </summary>
    /// <param name="sceneName">シーン名</param>
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// 操作説明のポップアップを表示する
    /// true = 表示中　false = 非表示
    /// </summary>
    public void SetExplanationUI(bool flag)
    {
        if (flag)
            _explanationUI.SetActive(true);
        else
            _explanationUI.SetActive(false);
    }
}
