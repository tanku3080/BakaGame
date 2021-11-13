using UnityEngine;

public class GameClearSection : MonoBehaviour
{
    /// <summary>一度だけ実行する</summary>
    private bool actionFalg = true;

    int collCount = 0;
    bool startFalag = false, reStartFalg = false;
    // Start is called before the first frame update
    void Start()
    {
        collCount = 0;
        FadeManager.Instance.FadeBlack();
        FadeManager.Instance.FadeSystem(FadeManager.FADE_STATUS.FADE_OUT);
    }

    // Update is called once per frame
    void Update()
    {
        if (FadeManager.Instance.fadeStopFlag && actionFalg)
        {
            if (collCount == 0)
            {
                collCount++;
                actionFalg = false;
                BGMManager.Instance.BGMSet(BGMManager.BGM_STATE.CLEAR).Play();
            }
            else if (collCount != 0 && startFalag)
            {
                BGMManager.Instance.BGMStop();
                FadeManager.Instance.SceneChangeSystem(FadeManager.SCENE_STATUS.START);
            }
            else if (collCount != 0 && reStartFalg)
            {
                BGMManager.Instance.BGMStop();
                FadeManager.Instance.SceneChangeSystem(FadeManager.SCENE_STATUS.GAME_PLAY);
            }
        }
    }

    public void GoStartButton()
    {
        FadeManager.Instance.FadeSystem(FadeManager.FADE_STATUS.FADE_IN, 0.002f);
        collCount++;
        actionFalg = true;
        startFalag = true;
    }
    public void GoReStartButton()
    {
        FadeManager.Instance.FadeSystem(FadeManager.FADE_STATUS.FADE_IN, 0.002f);
        collCount++;
        actionFalg = true;
        reStartFalg = true;
    }
}
