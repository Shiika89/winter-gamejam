using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
///  Time関連のUI、Scene遷移のスクリプト
/// </summary>

[RequireComponent(typeof(Text))]
public class TimeManager : MonoBehaviour
{

    [SerializeField, Header("スタート時間[s]")] float _gameTime = default;
    [SerializeField, Header("スタート時間のテキスト")] Text _timeText;

    /// <summary>
    ///  終了時間
    /// </summary>
    float _countTime;

    /// <summary>
    ///  Textコンポーネントと残り時間
    /// </summary>
    void Start()
    {
        // Textコンポーネント取得
        _timeText = GetComponent<Text>();
        // 残り時間を設定
        _countTime = _gameTime;
    }

    
    void Update()
    {
        // 残り時間を計算する
        _countTime += Time.deltaTime;

        // 1441秒(24時)超えたらテキストに表示されている秒数を強制的に0秒に表示させる。その後、Scene遷移の予定
        if (_countTime > 1441.0f)
        {
            _countTime = 0.0f;
        }
        // 361秒(6時)超えたらイベント発生 (現時点でイベント内容と時間は未定)
        else if (_countTime > 361.0f)
        {

        }
        

        // 残り時間[s]を60で割った整数値
        int minutes = Mathf.FloorToInt(_countTime / 60F);
        // 残り時間[s]からminutesで求めた整数値から60をかけた差
        int seconds = Mathf.FloorToInt(_countTime - minutes * 60);
        // minutesとsecondsの結果をストリング変換してテキスト表示
        _timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
