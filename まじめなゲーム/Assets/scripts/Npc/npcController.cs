using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;


public class npcController : MonoBehaviour
{


    //Animation animeition = null;

    Animation anime;
    
    public AnimationClip test1;
    public AnimationClip test2;

    [SerializeField] Animation  anime = null;

    enum STATE
    {
        Move1,Move2,Move3
    }

    
    void Start()
    {
        anime = GetComponent<Animation>();
    }

   
    void Update()
    {
        switch (test1)
        {
            case STATE.Move1:
                anime = null;
                break;
            case STATE.Move2:
                anime = null;
                break;
            case STATE.Move3:
                anime = null;
                break;
        }
    }


    IEnumerator ChangeTest1()
    {
        Animation.Stop();
    }

    void aniSet(STATE st)
    {
        
    }


}
