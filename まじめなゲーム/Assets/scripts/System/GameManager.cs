using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    /// <summary>タイムリミットになったらTrueにする</summary>
    [HideInInspector] public bool timeLimit = false;
    public Text timerText;
    [SerializeField] float totalTime =180;

    /// <summary>倒壊する建物を入れる</summary>
    [HideInInspector] public List<ObjController> objs = new List<ObjController>();

    void Start()
    {
        BGMManager.Instance.BGMSet(BGMManager.BGM_STATE.GAME).Play();
        FadeManager.Instance.FadeSystem(FadeManager.FADE_STATUS.FADE_OUT);
        AddBuildingObj();
    }

    private void AddBuildingObj()
    {
        var target = FindObjectsOfType<ObjController>();
        foreach (var item in target)
        {
            objs.Add(item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
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
            timerText.text = "<color=red>Timer</color>" + $"<color=red>{(int)totalTime}</color>";
        }
    }

    public void GameOver()
    {
        BGMManager.Instance.BGMStop();
        FadeManager.Instance.FadeSystem(FadeManager.FADE_STATUS.FADE_IN,0.02f,true, "GameOver");
    }

    public void GameClear()
    {
        PointController.Instance.GameEndPointSeve();
        BGMManager.Instance.BGMStop();
        FadeManager.Instance.FadeSystem(FadeManager.FADE_STATUS.FADE_IN,0.02f,true,"Ranking");
    }


}
