using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// リザルトUIを表示するスクリプト
/// </summary>
public class SetResultScript : MonoBehaviour
{
    [SerializeField] GameObject _resultUI;
    /// <summary>クリア時の背景</summary>
    [SerializeField, Header("クリア時の背景")] Sprite _clearImage;
    /// <summary>失敗時の背景</summary>
    [SerializeField, Header("失敗時の背景")] Sprite _failImage;
    [SerializeField] AudioManager _audioManager;

    Image _resultImage;

    bool _flag = false;

    bool _seFlag = false;
    private void Start()
    {
        _resultImage = _resultImage.transform.GetChild(0).GetComponent<Image>();
    }

    void Update()
    {
        if (_flag)
        {
            _resultImage.sprite = _clearImage;
            OneSE(1);
            _resultUI.SetActive(true);
        }
        else
        {
            _resultImage.sprite = _failImage;
            OneSE(2);
            _resultUI.SetActive(true);
        }
    }

    /// <summary>
    /// SEを一度だけ鳴らす為の関数
    /// </summary>
    /// <param name="index"></param>
    private void OneSE(int index)
    {
        if (!_seFlag)
        {
            _audioManager.RingSE(index);
            _seFlag = true;
        }
    }
}
