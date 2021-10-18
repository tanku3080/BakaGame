using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject player = null;
    [SerializeField] float playerSpeed = 20f;
    [SerializeField] float playerLimitSpeed = 60f;
    Rigidbody rd = null;
    // Start is called before the first frame update
    void Start()
    {
        rd = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //var mouseH = Input.GetAxis("Mouse H");
        //var mouseY = Input.GetAxis("Mouse Y");
    }

    private void FixedUpdate()
    {
        var h = Input.GetAxis("Horizontal") * playerSpeed / 100;
        var v = Input.GetAxis("Vertical") * playerSpeed / 100;

        if (v != 0 || h != 0)
        {
            rd.velocity = new Vector3(h, 0, v);
        }
    }
}
