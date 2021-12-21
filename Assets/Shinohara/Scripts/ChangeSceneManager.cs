using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneManager : MonoBehaviour
{
    [SerializeField] GameObject _fadeUI;
    /// <summary>説明用UI</summary>
    [SerializeField] GameObject _explanationUI;


    bool _explanationFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>フェード用UIを生成する</summary>
    public void SetFadeUI()
    {
        Instantiate(_fadeUI);
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SetExplanationUI()
    {
        if (!_explanationFlag)
        {
            _explanationUI.SetActive(true);
            _explanationFlag = true;
        }
        else
        {
            _explanationUI.SetActive(false);
            _explanationFlag = false;
        }
    }

}
