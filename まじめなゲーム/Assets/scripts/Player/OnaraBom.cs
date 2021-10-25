using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnaraBom : MonoBehaviour
{
    /// <summary>爆発までの時間</summary>
    [SerializeField] float expTime = 5;
    [SerializeField] float power = 0;
    [SerializeField] float radius = 0;
    [SerializeField] float upwardsModifier = 0;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Explosion();
        }
    }

    private void Explosion()
    {
        rb.AddExplosionForce(power, new Vector3(0,1,0), radius, upwardsModifier, ForceMode.Impulse);
        //Destroy(this.gameObject);
    }
}
