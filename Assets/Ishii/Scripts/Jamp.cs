using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jamp : MonoBehaviour
{
    [SerializeField] Rigidbody2D m_rb;
    [SerializeField] float m_jumpPower;
    [SerializeField] float m_jumpKeep;
    [SerializeField] float m_fallTime;

    bool m_isGround = true;
    bool m_fall;
    float m_posY;
    float m_time;
    

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Fall());
    }

    // Update is called once per frame
    void Update()
    {
        m_time += Time.deltaTime;
        Fall();

        if (Input.GetKeyDown(KeyCode.Space) && m_isGround)
        {
            m_rb.AddForce(Vector2.up * m_jumpPower, ForceMode2D.Impulse);
        }
        else if (Input.GetKey(KeyCode.Space) && !m_isGround && m_fall)
        {
            float time = Time.deltaTime;

            if (m_fallTime > time)
            {
                m_rb.velocity = new Vector2(0, 0);
            }
            //m_rb.AddForce(Vector2.up * m_jumpKeep, ForceMode2D.Force);
            Debug.Log("対空中");
        }
        Debug.Log(m_fall);
    }

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

    //IEnumerator Fall()
    //{
    //    m_posY = this.transform.position.y;

    //    yield return new WaitForSeconds(0.1f);

    //    if (m_posY > this.transform.position.y)
    //    {
    //        m_fall = true;
    //        yield return new WaitForSeconds(m_fallTime);
    //    }
    //    else
    //    {
    //        m_fall = false;
    //    }
    //}

    private void Fall()
    {
        //m_posY = this.transform.position.y;


        //if (m_time > 0.1f)
        //{
        //    if (m_posY > this.transform.position.y)
        //    {
        //        m_fall = true;
        //        m_time = 0;
        //    }
        //    else
        //    {
        //        m_fall = false;
        //    }
        //}
        //Debug.Log(m_time);

        if (this.transform.position.y > -2 && this.transform.position.y < 1)
        {
            m_fall = true;
        }
        else
        {
            m_fall = false;
        }
    }
}
