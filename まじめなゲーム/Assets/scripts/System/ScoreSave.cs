using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

/// <summary>スコアを保存したり呼び出したりするクラス</summary>
public class ScoreSave : Singleton<ScoreSave>
{
    public List<int> points = new List<int>();
    private int rankingVal = 0;

    /// <summary>ポイントの取得</summary>
    private void GetPoint()
    {
        for (int i = 0; i < 3; i++)
        {
            points.Add(PlayerPrefs.GetInt(i.ToString()));
        }
    }

    public void Save(int scoreVal)
    {
        GetPoint();

        bool oneTimePas = true;

        for (int i = 0; i < points.Count; i++)
        {
            Debug.Log($"{i}の値before");
            if (oneTimePas)
            {
                if (scoreVal != 0)
                {
                    Debug.Log($"{i}の値インプット");
                    //0又はそれ以上なら入れる。
                    if (points[i] == 0)
                    {
                        points[i] = scoreVal;
                        PrefsSet(i.ToString(), scoreVal);
                        rankingVal += 1;
                        Debug.Log($"{i}のtrue");
                    }
                    else if (points[i] > scoreVal)
                    {

                        if (i == 2)
                        {
                            PrefsSet(i.ToString(), scoreVal);
                            points[i++] = scoreVal;
                            rankingVal += 2;
                            Debug.Log($"{i}のa");
                        }
                        else//何故か3位でもここに行く
                        {
                            PrefsSet(i++.ToString(), scoreVal);
                            points[i++] = scoreVal;
                            rankingVal += i;
                            Debug.Log($"{i}のb");
                        }
                    }
                    oneTimePas = false;
                }
            }
            else break;
        }
    }
    public void SaveDel() => PlayerPrefs.DeleteAll();

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
        if (rankingVal > 3)
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
        foreach (var item in points)
        {
            Text text = objs.transform.GetChild(number).GetComponent<Text>();
            number++;
            text.text = $"{number}位：{item}";
        }
    }
}
