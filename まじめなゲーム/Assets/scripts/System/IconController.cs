using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconController : MonoBehaviour
{
    void LateUpdate()
    {
        this.transform.rotation = Camera.main.transform.rotation;
    }
}
