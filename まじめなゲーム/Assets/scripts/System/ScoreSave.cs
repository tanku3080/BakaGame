using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

/// <summary>スコアを保存したり呼び出したりするクラス</summary>
public class ScoreSave : Singleton<ScoreSave>
{

    private static readonly Dictionary<string, int> dic;
    private int rankOther = 0;

    /// <summary>記録を保存する機能で1ゲーム終了ごとにセーブを行う</summary>
    /// <param name="scoreValue">記録の値</param>
    /// <param name="scoreName">keyとなる文字列</param>
    public void Save(int scoreValue,string scoreName)
    {

        if (scoreValue > dic.Min().Value || dic.Count > 0)
        {
            PlayerPrefs.DeleteKey(dic.Min().Key);
            dic.Remove(dic.Min().Key);
        }
        else rankOther = scoreValue;
        dic.Add(scoreName, scoreValue);
        dic.OrderBy(t => t.Value);

        PlayerPrefs.SetInt(scoreName, scoreValue);
        PlayerPrefs.Save();
    }

    /// <summary>システム文字を表示する</summary>
    /// <param name="systemInput">もし、rankOtherが0ならランキング外の文字列,違うなら何位なのかの表示</param>
    public void SystemShow(Text systemInput)
    {
        if (rankOther == 0)
        {
            Debug.Log("ランキング外");
            systemInput.text = "ランキング外です";
            return;
        }
        else
        {
            Debug.Log("ランキング入り");
            systemInput.text = $"現在の順位は<color=red>{rankOther}位です！</color>";

            rankOther = 0;//元に戻す
        }
    }

    /// <summary>1～3までのランキングを表示するためのメソッド</summary>
    /// <param name="objs">攻撃するための処理</param>
    public void ShowRank(GameObject objs)
    {
        int number = 0;
        foreach (var item in dic)
        {
            Text text = objs.transform.GetChild(number).GetComponent<Text>();
            text.text = item.Value + item.Key;
            number++;
        }
    }
}
