using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

/// <summary>イベント用の物をマップに生成するスクリプト</summary>
public class PointEventGenerator : MonoBehaviour
{
    [SerializeField] List<Transform> eventPoint = null;
    // Start is called before the first frame update
    void Start()
    {
        eventPoint = eventPoint.OrderBy(a => Guid.NewGuid()).ToList();
    }

    // Update is called once per frame
    void Update()
    {
        //ここにNPCを生成するように書く
    }
}
