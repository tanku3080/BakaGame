using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>フェードとシーン切り替えのどちらかを実行する</summary>
public class FadeManager:Singleton<FadeManager>
{
    public enum SCENE_STATUS
    {
        START, GAME_PLAY, GAME_OVER, GAME_CLEAR,RANKING, NONE
    }
    public enum FADE_STATUS
    {
        FADE_IN, FADE_OUT, NONE
    }
    /// <summary>フェード処理が終わったかどうかを返す</summary>
    [HideInInspector] public bool fadeStopFlag;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    /// <summary>フェード機能のみを行う
    /// </summary>
    /// <param name="status">どんなフェードを行いたいか</param>
    /// <param name="fadeSpeed">Fadeの速度</param>
    /// <param name="canvas">Fadeさせるオブジェクト</param>
    /// <param name="isSceneChange">trueならフェード後にシーン切り替えを行う事が出来る</param>
    /// <param name="sceneName">isSceneChangeがtrueの場合に文字列を代入する事が出来る</param>
    public void FadeSystem(FADE_STATUS status = FADE_STATUS.NONE, float fadeSpeed = 0.02f,bool isSceneChange = false,string sceneName = null)
    {
        StartCoroutine(StartFadeSystem(status, fadeSpeed, gameObject.GetComponent<CanvasGroup>(),isSceneChange,sceneName));
    }
    /// <summary>画面をあえて黒く設定するだけのシステム</summary>
    public void FadeBlack()
    {
        gameObject.GetComponent<CanvasGroup>().alpha = 1;
    }
    private IEnumerator StartFadeSystem(FADE_STATUS _STATUS = FADE_STATUS.NONE, float fadeSpeed = 0.02f, CanvasGroup obj = null,bool sceneChange = false,string sceneName = null)
    {
        fadeStopFlag = false;
        switch (_STATUS)
        {
            case FADE_STATUS.FADE_IN:
                while (true)
                {
                    yield return null;
                    if (obj.alpha >= 1)
                    {
                        fadeStopFlag = true;
                        break;
                    }
                    else obj.alpha += fadeSpeed;
                }
                break;
            case FADE_STATUS.FADE_OUT:
                while (true)
                {
                    yield return null;
                    if (obj.alpha <= 0)
                    {
                        fadeStopFlag = true;
                        break;
                    }
                    else obj.alpha -= fadeSpeed;
                }
                break;
            case FADE_STATUS.NONE:
                break;
        }
        if (sceneChange)
        {
            SceneChangeSystem(SCENE_STATUS.NONE,sceneName);
        }
        yield return 0;
    }

    /// <summary>シーン切り替えのみを行う
    /// </summary>
    /// <param name="scene"切り替えたいシーン></param>
    public void SceneChangeSystem(SCENE_STATUS scene = SCENE_STATUS.NONE,string name = null)
    {
        string changeName = null;
        if (name != null) changeName = name;
        else
        {
            switch (scene)
            {
                case SCENE_STATUS.START:
                    changeName = "Start";
                    break;
                case SCENE_STATUS.GAME_PLAY:
                    changeName = "Game";
                    break;
                case SCENE_STATUS.GAME_OVER:
                    changeName = "GameOver";
                    break;
                case SCENE_STATUS.GAME_CLEAR:
                    changeName = "GameClear";
                    break;
                case SCENE_STATUS.RANKING:
                    changeName = "Ranking";
                    break;
                case SCENE_STATUS.NONE:
                    break;
            }
        }
        SceneManager.LoadScene(changeName);
    }
}
