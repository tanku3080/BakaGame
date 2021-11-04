using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjController : MonoBehaviour
{
    [SerializeField] float destroyTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            ObjDestroy();
        }
    }

    private void ObjDestroy()
    {
        Debug.Log("start");
        gameObject.GetComponent<BoxCollider>().enabled = false;
        Vector3 endPos = new Vector3(transform.position.x, -1000000, transform.position.z);
        transform.position = Vector3.Lerp(gameObject.transform.position, endPos, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Onara"))
        {
            ObjDestroy();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject)
        {
            Destroy(gameObject);
        }
    }
}
