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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        GameOver();
    }

    void Timer()
    {
        if (totalTime < 0)
        {
            timeLimit = true;
            return;
        }
        else
        {
            totalTime -= Time.deltaTime;
            timerText.text = "<color=red>Timer</color>" + ((int)totalTime).ToString();
        }
    }

    bool oneUseFlag = true;

    void GameOver()
    {
        if (timeLimit)
        {
            player.Dappun();
        }
        if (player.endOfDappun)
        {
            if (oneUseFlag)
            {
                FadeManager.Instance.FadeSystem(FadeManager.FADE_STATUS.FADE_IN);
                oneUseFlag = false;
            }
            if (FadeManager.Instance.FadeStop)
            {
                FadeManager.Instance.SceneChangeSystem(FadeManager.SCENE_STATUS.GAME_OVER);
            }
        }
    }


}
