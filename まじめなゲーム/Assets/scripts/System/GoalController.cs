using UnityEngine;

public class GoalController : MonoBehaviour
{
    private Vector3 objPosition;

    private void Start()
    {
        objPosition = gameObject.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(GameManager.Instance.player.transform);
        transform.position = new Vector3(objPosition.x, Mathf.Sin(Time.time) * 0.04f + objPosition.y, objPosition.z);
    }
}
