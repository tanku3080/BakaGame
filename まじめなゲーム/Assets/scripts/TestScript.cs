using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    [SerializeField] ScoreSave saveScript = null;

    //ランキングに入ったか否かを表示するUI
    [SerializeField] Text rankingInOrOther = null;

    //ランキングのテキストを入れる複素数
    [SerializeField] Text[] texts = null;

    [SerializeField] int velue = 1;
    [SerializeField] string playerName = "tasuku";
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            saveScript.Save(velue,playerName);
        }

        if (Input.GetKeyUp(KeyCode.U))
        {
            saveScript.SystemShow(rankingInOrOther);
        }

        if (Input.GetKeyUp(KeyCode.Return))
        {
            saveScript.ShowRank(texts);
        }
    }
}
