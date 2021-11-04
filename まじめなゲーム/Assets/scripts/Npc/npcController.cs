using System.Collections;
using UnityEngine;

public class NpcController : NPCManager
{
    bool isDie = false;
    // Start is called before the first frame update
    void Start()
    {
        SetRagdoll(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!anime.isPlaying && isDie == false)
        {
            AnimePlay(ANIME_STATE.SELECT);
        }
        if (isDie)
        {
            isDie = false;
            SetRagdoll(isDie);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag("Player"))
        {
            anime.Stop();
            isDie = true;
        }
    }
}
