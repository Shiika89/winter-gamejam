using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float m_jumpForce = 5;

    [SerializeField] Text m_textGameOver;

    [SerializeField] Slider m_skillGage;

    Rigidbody2D m_playerRb;

    bool m_isGround = true;

    bool m_isGameOver = false;

    void Start()
    {
        m_playerRb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// スペースキーが押されたら上に力を加える(ジャンプ１回)
    /// jumpForceの値を変更することでで飛ぶ大きさを変えることができる
    /// ※RigidBody2Dのコンポーネント追加する必要あり
    /// 
    /// スキルゲージが満タンになったら無敵状態になり、スキルゲージが空になる
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && m_isGround && !m_isGameOver)
        {
            m_playerRb.AddForce(Vector2.up * m_jumpForce, ForceMode2D.Impulse);
        }

        //if (m_skillGage.value == 3)
        //{
        //    m_skillGage.value = 0;
        //}
    }

    /// <summary>
    /// Playerの足元にあるコライダーが地面から離れたらジャンプできないようにする
    /// </summary>
    /// <param name="collision"></param>
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            m_isGround = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            m_isGround = false;
        }
    }

    /// <summary>
    /// 敵に当たったらゲームオーバーテキストを表示
    /// 
    /// アイテムに当たったらスキルゲージを１増やしてアイテムを削除
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Enemy"))
        {
            Text gameoverText = m_textGameOver.GetComponent<Text>();
            gameoverText.text = "Game Over";
        }

        if (collision.gameObject.tag == "Skill")
        {
            m_skillGage.value++;
            //Destroy(collision.gameObject);
        }
    }
}