using UnityEngine;

/// <summary>NPCアイコンに追加するスクリプト</summary>
public class IconController : MonoBehaviour
{
    [SerializeField] NpcController npcs = null;
    private Vector3 objPosition;
    private void Start()
    {
        objPosition = gameObject.transform.position;
    }

    private void Update()
    {
        if (npcs.die) Destroy(gameObject);
        else gameObject.transform.LookAt(GameManager.Instance.player.transform);
        transform.position = new Vector3(objPosition.x, Mathf.Sin(Time.time) * 0.04f + objPosition.y, objPosition.z);
    }
}
