using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /// <summary>タイムリミットになったらTrueにする</summary>
    public bool timeLimit = false;
    public Text timerText;
    [SerializeField] float totalTime =180;
    [SerializeField] Player player = null;


    /// <summary>ゲームがスタートしたらtrueにする</summary>
    [HideInInspector] public bool gameStart = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        GameOver();
    }

    /// <summary>残り時間を表示する</summary>
    void Timer()
    {
        if (totalTime < 0)
        {
            timeLimit = true;
            gameStart = false;
            return;
        }
        else
        {
            gameStart = true;
            totalTime -= Time.deltaTime;
            timerText.text = "<color=red>Timer</color>" + ((int)totalTime).ToString();
        }
    }

    bool oneUseFlag = true;

    /// <summary>ゲームオーバーに関する処理</summary>
    void GameOver()
    {
        if (player.endOfDappun)
        {
            if (oneUseFlag)
            {
                FadeManager.Instance.FadeSystem(FadeManager.FADE_STATUS.FADE_IN);
                oneUseFlag = false;
            }
            if (FadeManager.Instance.fadeStopFlag)
            {
                FadeManager.Instance.SceneChangeSystem(FadeManager.SCENE_STATUS.GAME_OVER);
            }
        }
    }


}
