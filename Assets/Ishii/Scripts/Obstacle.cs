using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.Instance.Invincible)
        {
            return;
        }
            // ここに当たったら行う処理を書く

            if (collision.tag == "Player")
            {
                GameManager.Instance.Hit();

                Animator anim = collision.gameObject.GetComponentInParent<Animator>();
                anim.SetTrigger("Damage");
            }
        }
    }
