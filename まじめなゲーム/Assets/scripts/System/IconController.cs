using UnityEngine;

public class IconController : MonoBehaviour
{
    [SerializeField] NpcController npcs = null;
    private void Start()
    {
        //iconは親オブジェクトであるNPCやオブジェクトの直下に置く
        npcs = transform.parent.GetComponent<NpcController>();
    }
    void LateUpdate()
    {
        if (npcs.die) Destroy(gameObject);
        else gameObject.transform.LookAt(GameManager.Instance.player.transform);
    }
}
