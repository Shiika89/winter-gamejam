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

    [SerializeField] private float m_speed;
    [SerializeField] float m_plusSpeed;

    //List<GameObject> m_goList = new List<GameObject>();
    private GameObject m_oddObject;
    private GameObject m_evenObject;

    private bool isSwitch = false;

    [SerializeField] float m_timerCount;
    [SerializeField] float m_interval;

    //private float m_timeCount;
    void Start()
    {
        StageGenelate(0);
        StageGenelate(m_posX);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(m_goList.Count);
        m_oddObject.transform.Translate(Vector3.left * Time.deltaTime * m_speed);

        m_timerCount += Time.deltaTime;
        if (m_timerCount > m_interval)
        {
            m_speed += m_plusSpeed;
            Debug.Log(m_timerCount);
            m_timerCount = 0;
        }

        if (m_oddObject.transform.position.x < -m_posX)
        {
            StageGenelate(m_posX);
        }

      
         m_evenObject.transform.Translate(Vector3.left * Time.deltaTime * m_speed);
        

        if (m_evenObject.transform.position.x < -m_posX)
        {
            StageGenelate(m_posX);
        }
        
    }

    void StageGenelate(float posX)
    {
        switch (isSwitch) 
        {
            case false:
                Destroy(m_oddObject);
                m_oddObject = Instantiate(m_stagePattern[RandomStageSelect()]
                , new Vector2(posX, 0f), Quaternion.identity);
                isSwitch = true;
                break;
            case true:
                Destroy(m_evenObject);
                m_evenObject = Instantiate(m_stagePattern[RandomStageSelect()]
                , new Vector2(posX, 0f), Quaternion.identity);
                isSwitch = false;
                break;
        }


        //m_cloneObject = Instantiate(m_stagePattern[RandomStageSelect()]
        //    , new Vector2(posX, 0f), Quaternion.identity);
        
        //Debug.Log(m_cloneObject+"を生成");
    }

    int RandomStageSelect()
    {
        int randomNum = Random.Range(0, m_stagePattern.Length-1);
        Debug.Log("ステージ"+randomNum);
        return randomNum;
    }

}
