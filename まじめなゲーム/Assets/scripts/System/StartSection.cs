using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSection : MonoBehaviour
{
    /// <summary>一度だけ実行する</summary>
    private bool actionFalg = true;

    int collCount = 0;
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
                BGMManager.Instance.BGMSet(BGMManager.BGM_STATE.OTHER).Play();
            }
            else
            {
                Debug.Log("押された");
                BGMManager.Instance.BGMStop();
                FadeManager.Instance.SceneChangeSystem(FadeManager.SCENE_STATUS.GAME_PLAY);
            }
        }
    }

    public void PushButton()
    {
        FadeManager.Instance.FadeSystem(FadeManager.FADE_STATUS.FADE_IN,0.002f);
        collCount++;
        actionFalg = true;
    }
}
