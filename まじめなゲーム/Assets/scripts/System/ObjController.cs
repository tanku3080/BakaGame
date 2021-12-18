using UnityEngine;

public class ObjController : MonoBehaviour
{
    /// <summary>anglerDrafの大きさで落ちる速さを決める</summary>
    [SerializeField] float gravitySpeed = 0.05f;
    [SerializeField] BoxCollider box = null;
    private Rigidbody rd = null;


    /// <summary>オブジェクトがDestoyされるまでの時間</summary>
    [SerializeField] readonly float objdestroyTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        box = box != null ? box : gameObject.GetComponent<BoxCollider>();
        rd = gameObject.GetComponent<Rigidbody>();
        rd.useGravity = rd.useGravity && false;
        rd.constraints = RigidbodyConstraints.FreezeAll;
    }

    public void ObjDestroy()
    {
        box.enabled = false;
        rd.useGravity = true;
        rd.constraints = RigidbodyConstraints.None;

        Destroy(gameObject,objdestroyTime);
    }


}
