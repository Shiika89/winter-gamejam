using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 時間を管理するスクリプト
/// </summary>
public class ManagerTime : MonoBehaviour
{
    /// <summary>開始時間 時</summary>
    [SerializeField, Header("開始時間　時"), Range(0, 23)] int _startTimeHour = default;
    /// <summary>開始時間　分</summary>
    [SerializeField, Header("開始時間　分"), Range(00, 60)] int _startTimeMinute = default;
    /// <summary>終了時間　時</summary>
    [SerializeField, Header("終了時間　時"), Range(0, 23)] int _endTimeHour = default;
    /// <summary>終了時間　分</summary>
    [SerializeField, Header("終了時間　時"), Range(00, 60)] int _endTimeMinute = default;
    [SerializeField, Header("スタート時間のテキスト")] Text _timeText;

    float _time;
    /// <summary>現在時刻　時</summary>
    static　int _currentHour = 0;
    /// <summary>現在時刻　分</summary>
    static int _currentMinute = 0;
    /// <summary>カウントを止める</summary>
    bool _endFlag = false;
    /// <summary>現在時刻　時</summary>
    public static int CurrentHour { get => _currentHour; set => _currentHour = value; }
    /// <summary>現在時刻　分</summary>
    public static int CurrentMinute { get => _currentMinute; set => _currentMinute = value; }

    void Start()
    {
        _currentHour = _startTimeHour;
        _currentMinute = _startTimeMinute;
        Debug.Log(_currentHour);
        
    }


    void Update()
    {
        _timeText.text = _currentHour.ToString() + ":" + _currentMinute.ToString("d2");

        if (GameManager.Instance.Game)
        {
            _time += Time.deltaTime;
        }

        if (!GameManager.Instance.Game && !_endFlag)
        {
            AddTime();
        }
    }

    /// <summary>
    /// 時間をカウントしたり
    /// 終了判定をする
    /// </summary>
    private void AddTime()
    {
        if (_time >= 1)
        {
            _currentMinute++;
            _time = 0;
        }

        if (_currentMinute == 60)
        {
            _currentHour++;
            _currentMinute = 0;
        }

        if (_currentHour == 24)
        {
            _currentHour = 0;
        }

        if (_currentHour + _currentMinute == _endTimeHour + _endTimeMinute) //クリア判定
        {
            GameManager.Instance.Clear();
            _endFlag = true;
        }
    }
}
