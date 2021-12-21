using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームを管理するスクリプト
/// </summary>
public class GameManager : MonoBehaviour
{
    static public GameManager Instance;

    [SerializeField] GameObject m_enemy = default;
    [SerializeField] int m_life = 3;
    bool m_game = false;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_game = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit()
    {
        // Enemyの敵が当たったら呼ぶ
        Debug.Log("hit");
        m_life -= 1;

        if (m_life == 0)
        {
            // ゲームオーバーの処理
        }
    }

    public void Clear()
    {
        // 時間まで生き残ったらclear
    }
}
