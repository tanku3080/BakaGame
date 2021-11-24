using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject player = null;
    [SerializeField] private Onara onaraClass = null;
    [SerializeField] private float playerSpeed = 20f;

    /// <summary>脱糞処理が終わった</summary>
    [HideInInspector] public bool endOfDappun = false;

    [SerializeField] Animator anime = null;

    internal bool oneTimeFlag = true;

    // Update is called once per frame
    void Update()
    {
        //var mouseH = Input.GetAxis("Mouse H");
        //var mouseY = Input.GetAxis("Mouse Y");
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        //マップの大きさに合わせてアセットも小さくしたので移動距離は1000で割る
        if (v != 0 && !endOfDappun || h != 0 && !endOfDappun)
        {
            player.transform.localPosition += playerSpeed * v * transform.forward / 10000;
            player.transform.Rotate(playerSpeed * Vector3.up / 10000,h);
        }

        if (onaraClass.jet == false)
        {
            if (v == 0 && h != 0)
            {
                anime.SetInteger("moveV", (int)h);
            }
            else
            {
                anime.SetInteger("moveV", (int)v);
            }
            anime.SetBool("jet",onaraClass.jet);
        }
        else
        {
            anime.SetInteger("moveV", 0);
            anime.SetBool("jet",onaraClass.jet);
            Debug.Log(onaraClass.jet);
        }

        if (GameManager.Instance.timeLimit && oneTimeFlag)
        {
            oneTimeFlag = false;
            Dappun();
        }

    }

    /// <summary>おもらし処理(仮)</summary>
    public void Dappun(float waitTime = 1.5f)
    {
        Debug.Log("脱糞完了");
        anime.SetTrigger("unko");
        endOfDappun = true;
        BGMManager.Instance.BGMStop();
        Invoke("GoToGameOver", waitTime);
    }
    private void GoToGameOver() => GameManager.Instance.GameOver();
}
