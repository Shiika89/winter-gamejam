using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutScript : MonoBehaviour
{
    [SerializeField] GameObject _fadeOutUI;

    private void Awake()
    {
        Instantiate(_fadeOutUI);
    }
}
