using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    [SerializeField] GameObject item = null;
    [SerializeField] List<Transform> itemPos = null;
    [SerializeField] int num = 0;

    // Start is called before the first frame update
    void Start()
    {
        List<int> numbers = new List<int>();
        for (int i = 0; i < num; i++)
        {
            bool flag = true;
            while (flag)
            {
                int n = Random.Range(0, itemPos.Count);
                if (!numbers.Contains(n))
                {
                    numbers.Add(n);
                    Instantiate(item, itemPos[n]);
                    flag = false;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
