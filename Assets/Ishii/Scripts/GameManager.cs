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
    bool m_clear = false;
    bool m_gameOver = false;

    private void Awake()
    {
        Instance = this;
        m_game = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit()
    {
        // Enemyの敵が当たったら呼ぶ
        Debug.Log("hit");

        Animator anim = m_enemy.GetComponent<Animator>();

        switch (m_life)
        {
            case 3:
                anim.SetTrigger("Life3");
                break;
            case 2:
                anim.SetTrigger("Life2");
                break;
            case 1:
                anim.SetTrigger("Life1");
                break;
            default:
                break;
        }

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

    public void GameOver()
    {

    }
}
