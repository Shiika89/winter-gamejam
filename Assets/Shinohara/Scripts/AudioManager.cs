using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SEを鳴らすスクリプト
/// </summary>
public class AudioManager : MonoBehaviour
{
    [Tooltip("0.ボタンを押した時 1.クリアSE 2.ゲームオーバーSE 3.ジャンプSE")]
    /// <summary>0 = ボタンを押した時 1= クリアSE 2 = ゲームオーバーSE 3 = ジャンプSE</summary>
    [SerializeField] AudioClip[] _useSE;

    AudioSource _audio;
    // Start is called before the first frame update
    void Start()
    {
        _audio = this.gameObject.AddComponent<AudioSource>();
    }

    /// <summary>
    /// SEを鳴らす関数
    /// </summary>
    /// <param name="index">SE配列の添え字</param>
    public void RingSE(int index)
    {
        _audio.PlayOneShot(_useSE[index]);
    }
}
