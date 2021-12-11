using System.Collections;
using UnityEngine;

public class NpcController : NPCManager
{
    public bool die = false;
    // Start is called before the first frame update
    void Start()
    {
        SetRagdoll(false);
        MoveSet(Random.Range(1, 5));
    }

    // Update is called once per frame
    void Update()
    {
        if (die)
        {
            anime.wrapMode = WrapMode.Once;
            die = false;
            SetRagdoll(die);
        }
    }

    private void MoveSet(int randomInt)
    {
        switch (randomInt)
        {
            case 1:
                AnimePlay(ANIME_STATE.IDOL);
                break;
            case 2:
                AnimePlay(ANIME_STATE.HAPPY1);
                break;
            case 3:
                AnimePlay(ANIME_STATE.POSITIVE1);
                break;
            case 4:
                AnimePlay(ANIME_STATE.POSITIVE2);
                break;
            case 5:
                AnimePlay(ANIME_STATE.HAPPY2);
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag("Player"))
        {
            anime.Stop();
            die = true;
        }
    }
}
