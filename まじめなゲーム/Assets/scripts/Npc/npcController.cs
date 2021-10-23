using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    enum ANIME_STATE
    {
        IDOL,POSITIVE1, POSITIVE2,HAPPY1, HAPPY2, HAPPY3,SELECT
    }
    [SerializeField] Animation anime = null;
    string animeName = null;
    // Start is called before the first frame update
    void Start()
    {
        anime = gameObject.GetComponent<Animation>();
        AnimePlay();
    }

    // Update is called once per frame
    void Update()
    {
        if (!anime.isPlaying)
        {
            AnimePlay(ANIME_STATE.SELECT);
        }
    }

    void AnimePlay(ANIME_STATE state = ANIME_STATE.IDOL)
    {

        switch (state)
        {
            case ANIME_STATE.IDOL:
                anime.clip = anime.GetClip("idle");
                break;
            case ANIME_STATE.POSITIVE1:
                anime.clip = anime.GetClip("applause");
                break;
            case ANIME_STATE.POSITIVE2:
                anime.clip = anime.GetClip("applause2");
                break;
            case ANIME_STATE.HAPPY1:
                anime.clip = anime.GetClip("celebration");
                break;
            case ANIME_STATE.HAPPY2:
                anime.clip = anime.GetClip("celebration2");
                break;
            case ANIME_STATE.HAPPY3:
                anime.clip = anime.GetClip("celebration3");
                break;
            case ANIME_STATE.SELECT:
                if (animeName == "idle") AnimePlay(ANIME_STATE.POSITIVE1);
                else if (animeName == "applause") AnimePlay(ANIME_STATE.POSITIVE2);
                else if (animeName == "applause2") AnimePlay(ANIME_STATE.HAPPY1);
                else if (animeName == "celebration") AnimePlay(ANIME_STATE.HAPPY2);
                else if (animeName == "celebration2") AnimePlay(ANIME_STATE.HAPPY3);
                else if (animeName == "celebration3") AnimePlay(ANIME_STATE.POSITIVE1);
                break;
        }
        anime.Play();
        animeName = anime.clip.name;
    }
}
