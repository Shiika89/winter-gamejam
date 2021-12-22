﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Playerのジャンプ処理
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField, Header("アイテムの個数")] int m_item = 3;

    [SerializeField, Header("ジャンプする力")] float m_jumpForce = 5;

    [SerializeField, Header("無敵時間")] float m_MutekiEnd = 3;

    [SerializeField, Header("スキルゲージ")] Slider m_skillGage;

    Rigidbody2D m_playerRb;　//Rigidbody2Dの変数

    float m_timer = 0;　//無敵時間を比較するための変数

    bool m_isGround = false; //接地判定のフラグ

    void Start()
    {
        m_playerRb = GetComponent<Rigidbody2D>();
        m_skillGage.value = 0;
    }

    /// <summary>
    /// スペースキーが押されたら上に力を加える(ジャンプ１回)
    /// jumpForceの値を変更することでで飛ぶ大きさを変えることができる
    /// ※RigidBody2Dのコンポーネント追加する必要あり
    /// 
    /// スキルゲージが満タンになったら
    /// ・無敵状態になる
    /// ・スキルゲージが空になる
    /// 
    /// 一定時間経過すると
    /// ・無敵時間のタイマーを０にする
    /// ・無敵状態を解除
    /// </summary>
    void Update()
    {
        if (Input.GetButtonDown("Jump") && m_isGround)
        {
            m_playerRb.AddForce(Vector2.up * m_jumpForce, ForceMode2D.Impulse);
        }

        if (m_skillGage.value == m_item)
        {
            m_skillGage.value = 0;
            GameManager.Instance.Invincible = true;
            m_timer += Time.deltaTime;

            if (m_timer == m_MutekiEnd)
            {
                m_timer = 0;
                GameManager.Instance.Invincible = false;
            }
        }
    }

    /// <summary>
    /// Playerの足元にあるコライダーが地面から離れたらジャンプできないようにする
    /// 
    /// Skillのタグがついたオブジェクトにぶつかるとスキルゲージを１増やす
    /// </summary>
    /// <param name="collision"></param>
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            m_isGround = true;
        }

        if (collision.gameObject.tag == "Skill")
        {
            m_skillGage.value++;
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        m_isGround = false;
    }
}