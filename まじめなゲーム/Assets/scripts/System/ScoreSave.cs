using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ScoreSave : MonoBehaviour
{

    private static Dictionary<string, int> dic;
    private int rankOther = 0;

    /// <summary>記録を保存する機能</summary>
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
            //ここにランキング外だった事を表示するテキストを出す
            return;
        }
        else
        {
            Debug.Log("ランキング入り");
            systemInput.text = $"現在の順位は<color=red>{rankOther}位です！</color>";
            //ここにランキングテキスト群を表示する
        }
    }

    /// <summary>ランキングを表示するためのメソッド</summary>
    public void ShowRank(Dictionary<string,int> input)
    {
        dic.OrderBy(t => t.Value);
        foreach (var item in dic)
        {
            input.Add(item.Key,item.Value);
        }
        
    }
}
