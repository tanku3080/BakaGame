using UnityEngine;
using UnityEngine.UI;

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
        int[] keep = new int[3];
        point.CopyTo(keep, 0);
        foreach (var item in keep)
        {
            Debug.Log("値は" + item);
        }

        bool oneTimePas = true;
        for (int i = 0; i < point.Length; i++)
        {
            if (oneTimePas)
            {
                //0又はそれ以上なら入れる。
                if (point[i] == 0)
                {
                    point[i] = scoreVal;
                    PrefsSet(i.ToString(), scoreVal);
                    rankingVal += 1;
                    Debug.Log($"{i}のtrue");
                }
                else if (point[i] > scoreVal)
                {
                    if (i == 2)
                    {
                        PrefsSet(i.ToString(), scoreVal);
                        point[i] = scoreVal;
                        rankingVal += 2;
                        Debug.Log($"{i}のa");
                    }
                    else
                    {
                        PrefsSet(i++.ToString(), scoreVal);
                        point[i++] = scoreVal;
                        rankingVal += i;
                        Debug.Log($"{i}のb");
                    }
                }
                oneTimePas = false;
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
        foreach (var item in point)
        {
            Text text = objs.transform.GetChild(number).GetComponent<Text>();
            number++;
            text.text = $"{number}位：{item}";
        }
    }
}
