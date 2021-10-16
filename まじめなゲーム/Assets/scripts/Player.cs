using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject player = null;
    [SerializeField] float playerSpeed = 100f;
    Rigidbody rd = null;
    // Start is called before the first frame update
    void Start()
    {
        rd = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        //var mouseH = Input.GetAxis("Mouse H");
        //var mouseY = Input.GetAxis("Mouse Y");

        if (v != 0)
        {
            rd.AddForce((transform.forward * playerSpeed) * v * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (h != 0)
        {
            rd.AddForce((transform.right * playerSpeed) * h * Time.deltaTime, ForceMode.VelocityChange);
        }
    }

    private void FixedUpdate()
    {
        
    }
}
