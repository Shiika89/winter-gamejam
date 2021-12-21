using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStageController : MonoBehaviour
{
    public float m_speed;
    [SerializeField] private float m_posX;
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * m_speed);
        if (transform.position.x < -m_posX)
        {
            Destroy(this.gameObject);
        }
    }

}
