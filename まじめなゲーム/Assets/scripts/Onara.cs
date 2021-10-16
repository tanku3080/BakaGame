using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// おならを出すためのスクリプト
/// </summary>
public class Onara : MonoBehaviour
{
    [SerializeField] GameObject player = null;
    [SerializeField] Transform onaraNozzle = null;
    [SerializeField] float onaraPow = 10000000f;
    Rigidbody rd = null;
    // Start is called before the first frame update
    void Start()
    {
        rd = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("おなら");
            rd.AddForce(onaraPow * Time.deltaTime * Vector3.up,ForceMode.Force);
        }
    }
}
