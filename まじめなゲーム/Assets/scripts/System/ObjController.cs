using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObjController : MonoBehaviour
{
    /// <summary>破棄される時間</summary>
    [SerializeField] float destroyTime = 5f;
    /// <summary>anglerDrafの大きさで落ちる速さを決める</summary>
    [SerializeField] float gravitySpeed = 0.05f;
    [SerializeField] BoxCollider box = null;
    readonly Rigidbody rd = null;

    // Start is called before the first frame update
    void Start()
    {
        box = box != null ? box : gameObject.GetComponent<BoxCollider>();
    }

    public void ObjDestroy()
    {
        box.enabled = false;
        rd.useGravity = true;
    }
}
