using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OssanAnim : MonoBehaviour
{
    /// <summary>
    /// アニメーション再生中は無敵にする
    /// </summary>
    public void SetInvincible()
    {
           GameManager.Instance.Invincible = true;
    }

    public void UnSetInvincible()
    {
        GameManager.Instance.Invincible = false;
    }

    public void Life()
    {
        if (GameManager.Instance.Invincible)
        {
            GameManager.Instance.Life--;
        }
    }
}
