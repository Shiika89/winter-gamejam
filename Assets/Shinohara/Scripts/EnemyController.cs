using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Tooltip("プレイヤーのライフ 減ると敵が移動します。")]
    /// <summary>playerのライフ</summary>
    [SerializeField] int _life = 0;

    Transform _player;
    /// <summary>プレイヤーがダメージを受けた時の移動量</summary>
    float _moveDistance;
    /// <summary>繰り返し処理を終了させる</summary>
    bool _flag = true;
    /// <summary>true　移動開始</summary>
    bool _moveFlag = false;
    float _totalMove = 0f;
    /// <summary>移動先</summary>
    Vector2 _movePos;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _moveDistance = Vector2.Distance(this.transform.position, _player.transform.position) / _life;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _moveFlag = true;
        }

        if (_moveFlag)
        {
            Debug.Log("hit");
            EnemyMove();
        }
    }

    /// <summary>敵の移動</summary>
    public void EnemyMove()
    {
        float f = 0f;
        _totalMove += _moveDistance;
        while (_flag)
        {
            f += this.transform.position.x + 0.01f;

            _movePos = new Vector2(_totalMove, 0);
            transform.position = Vector3.Lerp(this.transform.position, _movePos, f);

            if (f >= 1)
            {
                _moveFlag = false;
                _flag = false;
                break;
            }
        }

    }
}
