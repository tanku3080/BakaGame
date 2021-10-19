using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /// <summary>タイムリミットになったらTrueにする</summary>
    public bool timeLimit = false;
    public Text timerText;
    [SerializeField] float totalTime =0;
    int seconds;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalTime -= Time.deltaTime;
        seconds = (int)totalTime;
        timerText.text = seconds.ToString();


    }
}
