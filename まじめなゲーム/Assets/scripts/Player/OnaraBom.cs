using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnaraBom : MonoBehaviour
{
    /// <summary>爆発までの時間</summary>
    [SerializeField] float expTime = 5;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        expTime -= Time.deltaTime;
        if (expTime < 0)
        {
            Destroy(gameObject);
        }
    }
}
