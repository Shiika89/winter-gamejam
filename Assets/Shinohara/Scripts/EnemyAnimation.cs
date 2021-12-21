using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵のアニメーションを再生するスクリプト
/// </summary>
public class EnemyAnimation : MonoBehaviour
{
    Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    /// <summary>
    /// Playerが障害物にぶつかった時敵が近づいてくる
    /// ライフを減らす前に呼び出して下さい。
    /// </summary>
    public void EnemyMove(int life)
    {
        switch (life)
        {
            case 1:
                _anim.Play("Move1");
                break;
            case 2:
                _anim.Play("Move2");
                break;
            case 3:
                _anim.Play("Move3");
                break;
        }
    }
}
