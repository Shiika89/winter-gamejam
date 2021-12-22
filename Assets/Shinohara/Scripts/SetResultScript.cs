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
    /// <summary>ゲームプレイ中のBGM</summary>
    [SerializeField] AudioSource _bgm;
    /// <summary>制限時間を表示してるオブジェクト</summary>
    [SerializeField] GameObject _timeObj;

    Image _resultImage;

    bool _seFlag = false;
    private void Start()
    {
        _resultImage = _resultUI.transform.GetChild(0).GetComponent<Image>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SetUI(true);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            SetUI(false);
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

    /// <summary>
    ///リザルト時に表示する背景を決める
    ///引数がtrue=ゲームクリア false=ゲームオーバー
    /// </summary>
    /// <param name="flag"></param>
    public void SetUI(bool flag)
    {
        _bgm.enabled = false;
        _timeObj.SetActive(false);
        if (flag)
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
}
