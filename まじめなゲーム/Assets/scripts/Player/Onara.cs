using System.Collections;
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
    [SerializeField] private Transform onaraPlayPos = null;
    [SerializeField] private ParticleSystem onaraJetSystem = null;

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

    /// <summary>おなら爆弾を行うためのコスト</summary>
    [SerializeField] float onaraBomCost = 100f;
    /// <summary>おなら射撃を行うためのコスト</summary>
    [SerializeField] float onaraShotCost = 50f;
    ///<summary>おならの射程距離</summary>
    [SerializeField] float onaraRange = 1f;
    /// <summary>飛行の使用毎フレームの消費コスト</summary>
    [SerializeField] float onaraJetCost = 2f;
    /// <summary>アイテム取得時に回復する値</summary>
    [SerializeField,Tooltip("アイテム取得時にに回復する値")] float reCoverCost = 50f;
    /// <summary>爆弾を入れる</summary>
    [SerializeField] GameObject bom = null;


    /// <summary>playerカメラを格納</summary>
    [SerializeField] CinemachineVirtualCamera playercam = null;

    /// <summary>飛行おなら音の格納</summary>
    [SerializeField] AudioClip jumpOnara = null;
    /// <summary>脱糞音を追加する</summary>
    [SerializeField] AudioClip dieOnara = null;
    /// <summary>射撃を行うためのおなら</summary>
    [SerializeField] AudioClip shotOnara = null;

    Rigidbody rd = null;

    /// <summary>地面に接地しているか？</summary>
    private bool isGrand = false;
    /// <summary>対空中か？</summary>
    private bool grandKey = true;

    /// <summary>おなら射撃が行えるかどうかのキー</summary>
    private bool onarashotKey = false;
    /// <summary>おなら射撃の再使用時間</summary>
    [SerializeField] float onaraShotReUseTime = 1.5f;

    [HideInInspector] public bool jet = false;
    /// <summary>ボムが登録されているかを判定するのに使う</summary>
    [HideInInspector] public GameObject bomObj = null;

    // Start is called before the first frame update
    void Start()
    {
        rd = player.gameObject.GetComponent<Rigidbody>();
        onaraBar.maxValue = onaraBarMaxValue;
        onaraBar.value = onaraBarMaxValue;
        onaraJetSystem.transform.position = new Vector3(player.position.x,player.position.y - 1.5f,player.position.z);
    }

    private void Update()
    {
        if (onaraBar.value > 0)
        {
            if (Input.GetKeyUp(KeyCode.Q) && bomObj == null)
            {
                Debug.Log("爆弾");
                OnaraParameter(onaraBomCost);
                var playerPos = player.transform.position;

                bomObj = Instantiate(bom, playerPos - new Vector3(
                    0, -0.1f,0.1f), Quaternion.identity);
            }

            if (Input.GetMouseButtonUp(0) && onarashotKey == false)
            {
                Debug.Log("射撃");
                onarashotKey = true;
                StartCoroutine(ReCastTime(onaraShotReUseTime));
            }
        }
    }

    /// <summary>もう一度使えるまでの時間</summary>
    /// <param name="time">待機時間</param>
    /// <returns></returns>
    IEnumerator ReCastTime(float time)
    {
        float timeDalta = 0f;
        RaycastHit hit;
        Debug.DrawRay(transform.position,Vector3.back,Color.red,onaraRange);
        //射撃を行うコードをここに書く
        if (Physics.Raycast(transform.position,Vector3.back,out hit,onaraRange))
        {
            if (hit.collider.CompareTag("bulid"))
            {
                //建物に当たったらDestroyを使う。
                hit.collider.gameObject.GetComponent<ObjController>().ObjDestroy();
            }
            else if (hit.collider.CompareTag("eventEnemy"))
            {
                hit.collider.gameObject.GetComponent<EventNPCController>().NPCDie();
            }
        }

        while (true)
        {
            yield return null;
            if (time <= timeDalta) break;
            else timeDalta += Time.deltaTime;
        }
        yield return onarashotKey = false;
    }

    /// <summary>おならの値を消費するための処理</summary>
    /// <param name="input">消費する値</param>
    private void OnaraParameter(float input)
    {
        onaraBar.value -= input;
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && onaraBar.value > 0)
        {
            jet = true;
            if (rd.velocity.magnitude < limitOnara)
            {
                rd.AddForce(onaraPow * Time.deltaTime * player.up, ForceMode.Force);
                OnaraParameter(onaraJetCost);
                onaraJetSystem.Play();
            }
            else
            {
                if (player.position.y < playerJumpLimit)
                {
                    rd.AddRelativeForce(onaraPow * Time.deltaTime * player.up, ForceMode.Force);
                    OnaraParameter(onaraJetCost);
                    onaraJetSystem.Play();
                }
            }
        }
        else
        {
            onaraJetSystem.Stop();
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("item"))
        {
            collision.gameObject.GetComponent<ItemController>().MyDestroy();
            onaraBar.value += reCoverCost;
        }
    }
}
