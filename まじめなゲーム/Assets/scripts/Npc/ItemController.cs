using UnityEngine;

public class ItemController : MonoBehaviour
{
    /// <summary>ゆらゆら動く時間</summary>
    [SerializeField] float poinTime = 0.01f;
    /// <summary>上下運動を遅らす処理</summary>
    [SerializeField] float delayTime = 0.5f;
    private float firstPos = 0;

    /// <summary>アイテム取得時のポイント/// </summary>
    [SerializeField,Tooltip("アイテムのポイント")] int itemPointValue = 5;

    AudioSource source;
    SphereCollider sphere = null;
    // Start is called before the first frame update
    void Start()
    {
        firstPos = transform.position.y;
        source = gameObject.GetComponent<AudioSource>();
        sphere = gameObject.GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x,firstPos + Mathf.PingPong(Time.time * delayTime, poinTime),transform.position.z);
    }

    /// <summary>プレイヤーが触れたら破壊する</summary>
    public void MyDestroy()
    {
        PointController.Instance.PointSet(itemPointValue);
        sphere.enabled = false;
        source.Play();
        Destroy(gameObject,delayTime);
    }
}
