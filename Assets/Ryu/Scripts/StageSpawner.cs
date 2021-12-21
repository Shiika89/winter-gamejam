using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSpawner : MonoBehaviour
{
    public int m_nextNum = 0;
    private float m_randomNum;

    private Vector3 m_startPos;

    [SerializeField] private float m_posX;

    public GameObject[] m_stagePattern;
    private GameObject m_cloneObject;
    // Start is called before the first frame update
    void Start()
    {
        StageGenelate(0);
        StageGenelate(m_posX);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_cloneObject.transform.position.x < 0)
        {
            StageGenelate(m_posX);
        }
    }

    void StageGenelate(float posX)
    {
        m_cloneObject = Instantiate(m_stagePattern[RandomStageSelect()]
            , new Vector2(posX, 0f), Quaternion.identity);
        m_nextNum++;
        Debug.Log(m_cloneObject+"生成"+m_nextNum);
    }

    int RandomStageSelect()
    {
        int randomNum = Random.Range(0, m_stagePattern.Length);
        Debug.Log("乱数:"+randomNum);
        return randomNum;
    }
}
