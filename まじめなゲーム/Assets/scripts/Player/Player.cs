using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject player = null;
    [SerializeField] private float playerSpeed = 20f;

    /// <summary>脱糞処理が終わった</summary>
    [HideInInspector] public bool endOfDappun = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //var mouseH = Input.GetAxis("Mouse H");
        //var mouseY = Input.GetAxis("Mouse Y");

        var h = Input.GetAxis("Horizontal") * playerSpeed / 10000;
        var v = Input.GetAxis("Vertical") * playerSpeed / 10000;

        if (v != 0 || h != 0)
        {
            player.transform.position += new Vector3(h, 0, v);

        }
    }

    private void OnAnimatorMove()
    {
        
    }

    /// <summary>おもらし処理(仮)</summary>
    public void Dappun()
    {
        Debug.Log("脱糞完了");
        endOfDappun = true;
    }
}
