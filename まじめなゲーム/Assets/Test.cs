using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] FadeManager manager = null;
    [SerializeField] CanvasGroup group = null;
    Rigidbody rigidbody;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            manager.FadeSystem(FadeManager.FADE_STATUS.FADE_IN, 0.02f,group);
        }
    }
}
