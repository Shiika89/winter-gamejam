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

    public bool m_game = false;
   
    SetResultScript m_setResultScript = default;
    private void Awake()
    {
        Instance = this;
        m_game = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_setResultScript = GetComponent<SetResultScript>();
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
            m_setResultScript.SetUI(false);
            m_game = false;
        }
    }

    public void Clear()
    {
        m_setResultScript.SetUI(true);
    }

    public void GameOver()
    {

    }
}
