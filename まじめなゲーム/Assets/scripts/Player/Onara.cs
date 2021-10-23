using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;


/// <summary>
/// おならを出すためのスクリプト
/// </summary>
public class Onara : MonoBehaviour
{
    /// <summary>player本体を格納する</summary>
    [SerializeField] private Transform player = null;

    /// <summary>おならの発射位置</summary>
    [SerializeField] private Transform onaraNozzle = null;

    /// <summary>ジャンプに使うおならのちから</summary>
    private readonly float onaraPow = 400000f;

    /// <summary>playerがジャンプで行ける最高高度</summary>
    [SerializeField] float playerJumpLimit = 500f;

    /// <summary>おならの限界点</summary>
    [SerializeField] float limitOnara = 10f;

    /// <summary>おならのバーを入れる</summary>
    [SerializeField] Slider onaraBar = null;

    /// <summary>おならの最大値を入れる</summary>
    [SerializeField] float onaraBarMaxValue = 1000f;
    /// <summary>爆弾を入れる</summary>
    [SerializeField] GameObject bom = null;
    /// <summary>playerカメラを格納</summary>
    [SerializeField] CinemachineVirtualCamera playercam = null;
    /// <summary>飛行おなら音の格納</summary>
    [SerializeField] AudioClip jumpOnara = null;

    Rigidbody rd = null;

    /// <summary>地面に接地しているか？</summary>
    private bool isGrand = false;
    /// <summary>対空中か？</summary>
    private bool grandKey = true;

    [HideInInspector] public bool jet = false;
    /// <summary>ボムが登録されているかを判定するのに使う</summary>
    [SerializeField] GameObject bomObj = null;

    // Start is called before the first frame update
    void Start()
    {
        rd = player.gameObject.GetComponent<Rigidbody>();
        onaraBar.maxValue = onaraBarMaxValue;
        onaraBar.value = onaraBarMaxValue;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q) && bomObj == null)
        {
            bomObj = Instantiate(bom, player.transform.position - new Vector3(0, 0, 0.1f), Quaternion.identity);
        }
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && onaraBar.value > 0)
        {
            jet = true;
            if (rd.velocity.magnitude < limitOnara)
            {
                rd.AddForce(onaraPow * Time.deltaTime * player.up, ForceMode.Force);
                onaraBar.value--;
            }
            else
            {
                if (player.position.y < playerJumpLimit)
                {
                    rd.AddRelativeForce(onaraPow * Time.deltaTime * player.up, ForceMode.Force);
                    onaraBar.value--;
                }
            }
        }
        else
        {
            if (grandKey)
            {
                if (isGrand == false)
                {
                    playercam.GetCinemachineComponent<CinemachineTransposer>().m_YDamping = 0.5f;
                }
                else playercam.GetCinemachineComponent<CinemachineTransposer>().m_YDamping = 0f;
                grandKey = false;
            }
        }

        //制限高度に達したらrigitbodyを停止して一定高度まで戻されるようにする
        if (player.position.y > playerJumpLimit)
        {
            rd.velocity = Vector3.zero;
            player.position = new Vector3(player.position.x,player.position.y - 200f,player.position.z);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Grand"))
        {
            isGrand = true;
            grandKey = true;
            jet = false;
            Debug.Log("接地");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Grand"))
        {
            isGrand = false;
            Debug.Log("離脱");
        }
    }
}
