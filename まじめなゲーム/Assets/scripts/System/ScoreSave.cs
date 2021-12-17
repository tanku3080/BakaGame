using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

/// <summary>スコアを保存したり呼び出したりするクラス</summary>
public class ScoreSave : Singleton<ScoreSave>
{

    private readonly Dictionary<string, int> dic = new Dictionary<string, int>();
    private int[] inputValue = new int[3];
    private static int rankOther = 0;

    /// <summary>記録を保存する機能で1ゲーム終了ごとにセーブを行う</summary>
    /// <param name="scoreValue">記録の値</param>
    public void Save(int scoreValue)
    {
        rankOther = 0;

        for (int i = 0; i < inputValue.Length; i++)
        {
            if (!PlayerPrefs.HasKey(inputValue[i].ToString()))
            {
                Debug.Log("ここにはきた");
                //存在しなかったら入れる
                PlayerPrefs.SetInt(inputValue[i].ToString(), scoreValue);
                dic.Add(i.ToString(), scoreValue);
            }
            else
            {
                Debug.Log("例外きた");
                //keyに合致したらこの処理を行う
                if (dic.ContainsKey(i.ToString()))
                {
                    dic.Remove(inputValue[i].ToString());
                }
                dic.Add(i.ToString(),PlayerPrefs.GetInt(inputValue[i].ToString()));
            }
        }
        dic.OrderBy(t => t.Value);

        for (int i = 0; i < dic.Count; i++)
        {
            Debug.Log(PlayerPrefs.GetInt(i.ToString()));
        }

        for (int i = 0; i < dic.Count; i++)
        {
            if (dic.ContainsKey(inputValue[i].ToString()))
            {
                rankOther = i;
            }
        }
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
            number++;
            text.text = $"{number}位：{item.Value}";
        }
    }
}
