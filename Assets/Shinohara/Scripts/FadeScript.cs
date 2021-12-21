using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// FadeInプレハブを消す
/// </summary>
public class FadeScript : MonoBehaviour
{ 
   public void Delete()
    {
        Destroy(this.gameObject);
    }
}
