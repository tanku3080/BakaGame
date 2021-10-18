using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// おならを出すためのスクリプト
/// </summary>
public class Onara : MonoBehaviour
{
    /// <summary>player本体を格納する</summary>
    [SerializeField] Transform player = null;

    /// <summary>おならの発射位置</summary>
    [SerializeField] Transform onaraNozzle = null;

    /// <summary>ジャンプに使うおならのちから</summary>
    [SerializeField,Range(1f,2f)] float onaraPow = 2f;

    /// <summary>playerがジャンプで行ける最高高度</summary>
    [SerializeField] float playerJumpLimit = 500f;

    /// <summary>おならの限界点</summary>
    [SerializeField] float limitOnara = 10f;

    Rigidbody rd = null;
    // Start is called before the first frame update
    void Start()
    {
        rd = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (rd.velocity.magnitude < limitOnara)
            {
                Debug.Log("正規");
                rd.AddForce(onaraPow * Time.deltaTime * player.up, ForceMode.Force);
            }
            else
            {
                if (player.position.y < playerJumpLimit)
                {
                    Debug.Log("例外");
                    rd.AddRelativeForce(onaraPow * Time.deltaTime * player.up, ForceMode.Force);
                }
            }
        }

        //制限高度に達したらrigitbodyを停止して一定高度まで戻されるようにする
        if (player.position.y > playerJumpLimit)
        {
            rd.velocity = Vector3.zero;
            player.position = new Vector3(player.position.x,player.position.y - 200f,player.position.z);
        }
    }
}
