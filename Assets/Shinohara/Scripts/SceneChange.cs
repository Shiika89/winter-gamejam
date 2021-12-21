using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    ChangeSceneManager _sceneManager;
    // Start is called before the first frame update
    void Start()
    {
        _sceneManager = GameObject.Find("SceneManager").GetComponent<ChangeSceneManager>();
    }

    public void ChangeScene(string name)
    {
        _sceneManager.ChangeScene(name);
    }
}
