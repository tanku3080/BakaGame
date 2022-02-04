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

    [SerializeField] private SphereCollider exp = null;
    Rigidbody rb;

    AudioSource source = null;

    float time = 0;
    /// <summary>一度しか使わない判定</summary>
    private bool oneFlag = true;

    // Start is called before the first frame update
    void Start()
    {
        exp.enabled = false;
        rb = GetComponent<Rigidbody>();
        source = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (expTime < time && oneFlag)
        {
            oneFlag = false;
            Explosion();
        }
    }

    private void Explosion()
    {
        source.Play();
        exp.enabled = true;
        rb.AddExplosionForce(power, new Vector3(0,1,0), radius, upwardsModifier, ForceMode.Impulse);
        Destroy(gameObject,1.5f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Npc"))
        {
            other.gameObject.GetComponent<NpcController>().die = true;
        }
        else if (other.gameObject.CompareTag("eventEnemy"))
        {
            other.gameObject.GetComponent<EventNPCController>().NPCDie();
        }

        if (other.gameObject.CompareTag("build"))
        {
            other.gameObject.GetComponent<ObjController>().ObjDestroy();
        }
    }
}
