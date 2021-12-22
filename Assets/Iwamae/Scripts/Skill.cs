using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// スキルゲージの管理
/// </summary>
public class Skill : MonoBehaviour
{

    [SerializeField, Header("スキルゲージ")] Slider m_skillGage;

    [SerializeField, Header("アイテムの個数")] int m_item = 3;

    [SerializeField, Header("無敵時間")] float m_MutekiEnd = 3;

    public bool m_isMuteki = false; //無敵状態のフラグ

    private float m_timer = 0;　//無敵時間を比較するための変数

    /// <summary>
    /// ゲームが始まった時はスキルゲージの値を０にする
    /// </summary>
    void Start()
    {
        m_skillGage.value = 0;
    }

    /// <summary>
    /// アイテムを一定個数（Inspectorで設定可能）集めるとスキルゲージが０になり、
    /// 無敵状態（障害物の判定がなくなる）になる
    /// 
    /// 一定時間後（Inspectorで設定可能）無敵時間を終了する
    /// </summary>
    void Update()
    {
        if (m_skillGage.value == m_item)
        {
            m_skillGage.value = 0;
            m_isMuteki = true;
            m_timer += Time.deltaTime;

            if(m_timer == m_MutekiEnd)
            {
                m_timer = 0;
                m_isMuteki = false;
            }
        }
    }

    /// <summary>
    /// Playerのタグがついたオブジェクトにぶつかるとスキルゲージを１増やし、
    /// このスクリプトがついたオブジェクトを削除する
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            m_skillGage.value++;
            Destroy(collision.gameObject);
        }
    }
}
