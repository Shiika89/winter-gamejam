using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSpawner : MonoBehaviour
{
    public List<GameObject> StagePattern;
    private Vector2 m_startPos;
    private float m_screenHalfWidth;
    public GameObject screenObject;
    // Start is called before the first frame update
    void Start()
    {
        m_startPos = transform.position;
        m_screenHalfWidth = transform.localScale.x/2;
    }

    // Update is called once per frame
    void Update()
    {

        if (screenObject.transform.position.x < 0)
        {
            GenerateScreen();
        }
    }

    public void GenerateScreen()
    {

    }
}
