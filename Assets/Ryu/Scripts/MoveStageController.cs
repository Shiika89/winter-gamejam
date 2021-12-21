using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStageController : MonoBehaviour
{
    public float m_speed;
    private Vector3 m_startPos;
    [SerializeField] private float m_repeetPosX;
    [SerializeField] float m_diffrentPosX;
    // Start is called before the first frame update
    void Start()
    {
        m_startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * m_speed);
        if (transform.position.x < -m_repeetPosX)
        {
            transform.position = m_startPos+new Vector3(m_diffrentPosX,0,transform.position.z);
        }
    }
}
