using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testNPC : NPCManager
{
    // Start is called before the first frame update

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("あちょおおおおお");
        if(Rigidbody =)
        {
            ragdollRigidbodies.true;
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Rigidbody rd = this.GetComponent<Rigidbody>(); //Rigidbodyを取得
        
        Vector3 force = new Vector3(0.0f, 1.0f, 0.0f);
        rd.AddForce(force);
    }
}
