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
    /// <summary>
    /// NPCのリスト
    /// </summary>
    [SerializeField] List<GameObject> NPC_List;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Explosion()
    {
        foreach (var NPC in NPC_List)
        {
            if (Vector3.Distance(this.transform.position, NPC.transform.position) <= radius)
            {
                Rigidbody rb;
                rb = NPC.gameObject.GetComponent<Rigidbody>();
                rb.AddExplosionForce(power, this.transform.position, radius, upwardsModifier, ForceMode.Impulse);
            }
        }        
        Destroy(this.gameObject);
    }    
}
