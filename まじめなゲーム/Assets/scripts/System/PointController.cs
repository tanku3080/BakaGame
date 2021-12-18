using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>ポイントを画面に表示したりするクラス</summary>
public class PointController : Singleton<PointController>
{
    [SerializeField] Text pointUI = null;
    private int pointValue = 0;

    // Update is called once per frame
    void Update()
    {
        pointUI.text = "Point:" + pointValue.ToString();  
    }

    /// <summary>ポイント加算するメソッド</summary>
    /// <param name="pointVal">加算する値</param>
    public void PointSet(int pointVal)
    {
        pointValue += pointVal;
    }

    /// <summary>ゲーム終了時にポイントを保存する機能</summary>
    public void GameEndPointSeve()
    {
        ScoreSave.Instance.Save(pointValue);
    }
}
