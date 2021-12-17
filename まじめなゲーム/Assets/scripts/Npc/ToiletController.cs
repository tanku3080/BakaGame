using UnityEngine;

public class ToiletController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().endOfDappun = true;
            GameManager.Instance.GameClear();
        }
    }
}
