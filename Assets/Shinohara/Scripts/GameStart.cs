using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public void GameStartFunc()
    {
        GameManager.Instance.Game = true;
        ManagerTime._endFlag = false;
    }
}
