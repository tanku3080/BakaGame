using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject player = null;
    [SerializeField] private Onara onaraClass = null;
    [SerializeField] private float playerSpeed = 20f;

    /// <summary>脱糞処理が終わった</summary>
    [HideInInspector] public bool endOfDappun = false;

    [SerializeField] Animator anime = null;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //var mouseH = Input.GetAxis("Mouse H");
        //var mouseY = Input.GetAxis("Mouse Y");

        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        //マップの大きさに合わせてアセットも小さくしたので移動距離は1000で割る
        if (v != 0 || h != 0)
        {
            player.transform.position += new Vector3(h, 0, v) * playerSpeed / 10000;
        }

        if (onaraClass.jet == false)
        {
            anime.SetInteger("moveV", (int)v);
            anime.SetBool("jet",onaraClass.jet);
        }
        else
        {
            anime.SetInteger("moveV", 0);
            anime.SetBool("jet",onaraClass.jet);
            Debug.Log(onaraClass.jet);
        }

    }

    /// <summary>おもらし処理(仮)</summary>
    public void Dappun()
    {
        Debug.Log("脱糞完了");
        endOfDappun = true;
    }
}
