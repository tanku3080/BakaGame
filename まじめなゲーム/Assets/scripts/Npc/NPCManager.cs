using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class NPCManager : MonoBehaviour
{
    public Animation anime = null;
    [HideInInspector] public enum ANIME_STATE
    {
        IDOL, POSITIVE1, POSITIVE2, HAPPY1, HAPPY2, HAPPY3
    }


    //リグドール関連
    public　Animator animator;
    public Rigidbody[] ragdollRigidbodies;
    // Start is called before the first frame update
    void Start()
    {
        anime = gameObject.GetComponent<Animation>();
        animator = GetComponent<Animator>();
        ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
    }

    /// <summary>アニメーションを再生する</summary>
    /// <param name="state">再生するアニメーションの種類</param>
    public void AnimePlay(ANIME_STATE state)
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
        }
        anime.wrapMode = WrapMode.Loop;
        anime.Play();
    }


    public void SetRagdoll(bool isEnabled)
    {
        foreach (Rigidbody rigidbody in ragdollRigidbodies)
        {
            rigidbody.isKinematic = isEnabled;
            //animator.enabled = isEnabled;
            anime.Stop();
        }
    }
}
