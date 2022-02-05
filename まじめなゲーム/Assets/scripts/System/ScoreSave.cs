using UnityEngine;
using UnityEngine.UI;

/// <summary>スコアを保存したり呼び出したりするクラス</summary>
public class ScoreSave : Singleton<ScoreSave>
{
    public static int points;

    public void Save(int scoreVal)
    {
        points = scoreVal;        
    }

    /// <summary>1～3までのランキングを表示するためのメソッド</summary>
    /// <param name="objs">攻撃するための処理</param>
    public void ShowRank(GameObject objs)
    {
        Text text = objs.GetComponent<Text>();
        text.text = $"{points}!!";
    }
}
