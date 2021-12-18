using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class NpcController : NPCManager
{
    /// <summary>倒す際に呼び出す</summary>
    public bool die = false;
    private BoxCollider collider = null;
    // Start is called before the first frame update
    void Start()
    {
        collider = gameObject.GetComponent<BoxCollider>();
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
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("接触成功");
            anime.Stop();
            collider.enabled = true;
            die = true;
        }
    }
}
