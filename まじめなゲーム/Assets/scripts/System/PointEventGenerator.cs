using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

/// <summary>イベント用の物をマップに生成するスクリプト</summary>
public class PointEventGenerator : MonoBehaviour
{
    [SerializeField] List<Transform> eventPoint = null;

    /// <summary>生成するイベントの数(eventPointより多めに書かない事)</summary>
    [SerializeField] int instanceEventValue = 20;
    // Start is called before the first frame update
    void Start()
    {
        //もしも
        if (eventPoint.Count < instanceEventValue)
        {
            Debug.Log("数が釣り合っていないので初期値に修正");
            instanceEventValue = 20;
        }
        eventPoint = eventPoint.OrderBy(a => Guid.NewGuid()).ToList();

        for (int i = 0; i < instanceEventValue; i++)
        {
            //暴漢が用意できないために仮のNPCを実装
            var n = Instantiate((GameObject)Resources.Load("NPC1"),eventPoint[i]);
        }
    }
}
