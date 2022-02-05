using UnityEngine;
using UnityEngine.UI;

public class RankingSection : MonoBehaviour
{
    [SerializeField] GameObject rankingTexts = null;
    private bool actionFalg = true;

    int collCount = 0;


    void Start()
    {
        collCount = 0;
        FadeManager.Instance.FadeBlack();
        FadeManager.Instance.FadeSystem(FadeManager.FADE_STATUS.FADE_OUT);

        ScoreSave.Instance.ShowRank(rankingTexts);
    }



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
            else
            {
                Debug.Log("押された");
                BGMManager.Instance.BGMStop();
            }
        }
    }

    public void GoStartButton()
    {
        FadeManager.Instance.FadeSystem(FadeManager.FADE_STATUS.FADE_IN, 0.002f);
        collCount++;
        actionFalg = true;
        FadeManager.Instance.SceneChangeSystem(FadeManager.SCENE_STATUS.START);
    }
    public void GoReStartButton()
    {
        FadeManager.Instance.FadeSystem(FadeManager.FADE_STATUS.FADE_IN, 0.002f);
        collCount++;
        actionFalg = true;
        FadeManager.Instance.SceneChangeSystem(FadeManager.SCENE_STATUS.GAME_PLAY);
    }

}
