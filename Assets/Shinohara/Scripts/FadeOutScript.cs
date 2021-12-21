using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームシーンに遷移後
/// フェードアウトから始まるように
/// プレハブを生成する
/// </summary>
public class FadeOutScript : MonoBehaviour
{
    [SerializeField] GameObject _fadeOutUI;

    private void Awake()
    {
        Instantiate(_fadeOutUI);
    }
}
