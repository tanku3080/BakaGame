using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

/// <summary>スコアを保存したり呼び出したりするクラス</summary>
public class ScoreSave : Singleton<ScoreSave>
{
    public int[] point = new int[3];
    private int rankingVal = 0;

    /// <summary>ポイントの取得</summary>
    private void GetPoint()
    {
        for (int i = 0; i < point.Length; i++)
        {
            point[i] = PlayerPrefs.GetInt(i.ToString());
        }
    }

    public void Save(int scoreVal)
    {
        GetPoint();
        for (int i = 0; i < point.Length; i++)
        {
            //0又はそれ以上なら入れる。
            if (point[i] == 0)
            {
                point[i] = scoreVal;
                PrefsSet(i.ToString(),scoreVal);
                rankingVal += i++;
                break;
            }
            else if (point[i] > scoreVal)
            {
                if (i == 2)
                {
                    PrefsSet(i.ToString(),scoreVal);
                    point[i] = scoreVal;
                    rankingVal += i++;
                }
                else
                {
                    PrefsSet(i++.ToString(),scoreVal);
                    point[i++] = scoreVal;
                    rankingVal += i + 2;
                }
                break;
            }
        }
    }

    //Saveする為にする事。
    private void PrefsSet(string delKey,int inputVal)
    {
        PlayerPrefs.DeleteKey(delKey);
        PlayerPrefs.SetInt(delKey,inputVal);

    }

    /// <summary>システム文字を表示する</summary>
    /// <param name="systemInput">もし、rankOtherが0ならランキング外の文字列,違うなら何位なのかの表示</param>
    public void SystemShow(Text systemInput)
    {
        if (rankingVal == 0)
        {
            Debug.Log("ランキング外");
            systemInput.text = "ランキング外です";
            return;
        }
        else
        {
            Debug.Log("ランキング入り");
            systemInput.text = $"現在の順位は<color=red>{rankingVal}位です！</color>";
        }
    }

    /// <summary>1～3までのランキングを表示するためのメソッド</summary>
    /// <param name="objs">攻撃するための処理</param>
    public void ShowRank(GameObject objs)
    {
        int number = 0;
        foreach (var item in point)
        {
            Text text = objs.transform.GetChild(number).GetComponent<Text>();
            number++;
            text.text = $"{number}位：{item}";
        }
    }

    /*

    private readonly Dictionary<string, int> dic = new Dictionary<string, int>();
    private int[] inputValue = new int[3];
    private static int rankOther = 0;

    /// <summary>記録を保存する機能で1ゲーム終了ごとにセーブを行う</summary>
    /// <param name="scoreValue">記録の値</param>
    public void Save(int scoreValue)
    {
        rankOther = 0;
        dic.Clear();
        SaveSet(ref scoreValue);

        //保存した物をdicに入れる部分
        for (int i = 0; i < 3; i++)
        {
            dic.Add(i.ToString(),PlayerPrefs.GetInt(i.ToString()));
        }
        dic.OrderBy(t => t.Value);

        //今何位なのか値を代入する箇所
        for (int i = 0; i < dic.Count; i++)
        {
            if (dic.ContainsKey(inputValue[i].ToString()))
            {
                rankOther = i;
            }
        }
    }
    */
}
