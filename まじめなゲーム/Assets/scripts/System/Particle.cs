using UnityEngine;

/// <summary>particleを再生する建物に付ける</summary>
public class Particle : MonoBehaviour
{
    ParticleSystem system;
    // Start is called before the first frame update
    void Start()
    {
        system = gameObject.GetComponent<ParticleSystem>();
        system.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (system.isStopped)
        {
            Destroy(this.gameObject);
        }
    }
}
