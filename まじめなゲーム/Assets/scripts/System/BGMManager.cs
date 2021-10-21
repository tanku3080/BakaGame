using UnityEngine;

public class BGMManager : Singleton<BGMManager>
{
    /// <summary>BGMの種類を管理するステート</summary>
    public enum BGM_STATE
    {
        GAME, CLEAR, OVER, OTHER
    }
    AudioSource source;

    private void Start()
    {
         source = gameObject.GetComponent<AudioSource>();
    }

    [SerializeField] AudioClip game = null, clear = null, over = null, other = null;
    [HideInInspector] public bool BGMPlaying = false;
    public AudioSource BGMSet(BGM_STATE state)
    {
        switch (state)
        {
            case BGM_STATE.GAME:
                source.clip = game;
                break;
            case BGM_STATE.CLEAR:
                source.clip = clear;
                break;
            case BGM_STATE.OVER:
                source.clip = over;
                break;
            case BGM_STATE.OTHER:
                source.clip = other;
                break;
        }
        BGMPlaying = true;
        return source;
    }

    public void BGMStop()
    {
        source.Stop();
        BGMPlaying = false;
    }
}
