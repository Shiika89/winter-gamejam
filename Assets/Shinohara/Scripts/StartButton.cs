using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// カーソルがスタートボタンに乗った時
/// 画像を変えるスクリプト
/// </summary>
public class StartButton : MonoBehaviour
{
    /// <summary>乗っている間の画像 </summary>
    [SerializeField, Header("乗っている間の画像")] Sprite _chageimage;
    /// <summary>乗っていない時の画像 </summary>
    Sprite _beforeimage;
    Image _image;

    public void Start()
    {
        _image = GetComponent<Image>();
        _beforeimage = _image.sprite;
    }

    /// <summary>
    /// 画像を切り替える関数
    /// </summary>
    /// <param name="flag"></param>
    public void ChageImage(bool flag)
    {
        if (flag)
            _image.sprite = _chageimage;
        else
            _image.sprite = _beforeimage;
        
    }
}
