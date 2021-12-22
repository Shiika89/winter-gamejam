using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 画面が暗転中に
/// タイトルシーンからゲームシーンに遷移する
/// </summary>
public class SceneChange : MonoBehaviour
{
    ChangeSceneManager _sceneManager;
    // Start is called before the first frame update
    void Start()
    {
        _sceneManager =GameObject.Find("SceneManager").GetComponent<ChangeSceneManager>();
    }

    /// <summary>
    /// ChangeSceneManager内のシーン遷移関数を呼び出す
    /// </summary>
    /// <param name="name">シーン名</param>
    public void ChangeScene(string name)
    {
        _sceneManager.ChangeScene(name);
    }
}
