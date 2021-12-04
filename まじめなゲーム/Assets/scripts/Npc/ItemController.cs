using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    /// <summary>ゆらゆら動く時間</summary>
    [SerializeField] float poinTime = 0.01f;
    [SerializeField] float delayTime = 0.8f;
    private float firstPos = 0;
    // Start is called before the first frame update
    void Start()
    {
        firstPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x,firstPos + Mathf.PingPong(Time.time * delayTime, poinTime),transform.position.z);
    }
}
