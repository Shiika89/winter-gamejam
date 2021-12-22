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
    /// <summary>プレイ中がどうか</summary>
    bool m_game = false;
    /// <summary>無敵かどうか</summary>
    bool _invincible = false;
    /// <summary>無敵かどうか</summary>
    public bool Invincible { get => _invincible; set => _invincible = value; }
    /// <summary>プレイ中がどうか</summary>
    public bool Game { get => m_game; set => m_game = value; }

    public int Life { get => m_life; set => m_life = value; }

    SetResultScript m_setResultScript = default;

    

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_setResultScript = GetComponent<SetResultScript>();
    }

    /// <summary>敵のアニメーションを再生</summary>
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

        if (m_life == 0 && m_game)
        {
            m_setResultScript.SetUI(false);
            m_game = false;
        }
    }

    /// <summary>クリア背景を出す </summary>
    public void Clear()
    {
        m_setResultScript.SetUI(true);
        m_game = false;
    }
}
