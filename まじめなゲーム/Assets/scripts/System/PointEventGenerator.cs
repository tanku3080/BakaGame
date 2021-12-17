using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

/// <summary>イベント用の物やオブジェクトをマップに生成するスクリプト</summary>
public class PointEventGenerator : MonoBehaviour
{

    /// <summary>生成するイベントの数(eventPointより多めに書かない事)</summary>
    [SerializeField, Tooltip("数は必ず暴漢の最高数以下にする")] int EventInstanceValue = 20;

    /// <summary>イベント発生オブジェクト</summary>
    private List<Transform> eventPoint = null;
    /// <summary>イベントオブジェクトを入れる箱</summary>
    [SerializeField] Transform eventObj = null;

    /// <summary>goalポイントの座標を入れる</summary>
    private List<Transform> goalPoint = null;
    /// <summary>Goalオブジェクトを入れる箱</summary>
    [SerializeField] Transform goaltObj = null;


    private List<Transform> itemPos = null;
    [SerializeField] Transform itemObj = null;
    [SerializeField,Tooltip("数は必ずアイテムオブジェクトの最高数以下にする")] int itemIncetanceValue = 20;
    // Start is called before the first frame update
    void Start()
    {
        GoalPointIncetance();
        EventPointIncetance();
        ItemPointIncetance();
    }

    /*オブジェクトを配置する際には地面と接触しないようにかつ、地面に近づけて配置、登録してください。*/


    /// <summary>Goal位置を与えられた値から一つ選んで出現させる。</summary>
    private void GoalPointIncetance()
    {

        goalPoint = ObjSetUp(goaltObj).OrderBy(a => Guid.NewGuid()).ToList();

        var endPoint = Instantiate((GameObject)Resources.Load("toilet"), goalPoint.First());
    }

    /// <summary>おならバーを回復させるアイテムを設置する</summary>
    private void ItemPointIncetance()
    {

        itemPos = ObjSetUp(itemObj).OrderBy(a => Guid.NewGuid()).ToList();

        for (int i = 0; i < itemIncetanceValue; i++)
        {
            //物が用意できないために仮のNPCを実装
            var n = Instantiate((GameObject)Resources.Load("item"), itemPos[i]);

        }

    }

    /// <summary>イベント用NPCを配置する処理を作る</summary>
    private void EventPointIncetance()
    {
        eventPoint = ObjSetUp(eventObj).OrderBy(a => Guid.NewGuid()).ToList();
        //もしも
        if (eventPoint.Count < EventInstanceValue)
        {
            Debug.Log("数が釣り合っていないので初期値に修正");
            EventInstanceValue -= 10;
        }

        for (int i = 0; i < EventInstanceValue; i++)
        {
            //暴漢が用意できないために仮のNPCを実装
            var n = Instantiate((GameObject)Resources.Load("NPC1"), eventPoint[i]);
        }
    }

    private List<Transform> ObjSetUp(Transform obj)
    {
        List<Transform> list = new List<Transform>();
        for (int i = 0; i < obj.childCount; i++)
        {
            list.Add(obj.transform.GetChild(i));
        }
        return list;
    }
}
