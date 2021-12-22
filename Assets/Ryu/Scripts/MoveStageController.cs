using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStageController : MonoBehaviour
{
    [SerializeField] private float m_speed;
    [SerializeField] float m_plusSpeed;
    [SerializeField] private float m_posX;
    void Update()
    {
        //transform.Translate(Vector3.left * Time.deltaTime * m_speed);
        //m_speed += m_plusSpeed;
        //if (transform.position.x < -m_posX)
        //{
        //    Destroy(this.gameObject);
        //}
    }

}
