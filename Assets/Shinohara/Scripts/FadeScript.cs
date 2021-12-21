using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 自身を消す
/// </summary>
public class FadeScript : MonoBehaviour
{
    public void Delete()
    {
        Destroy(this.gameObject);
    }
}
