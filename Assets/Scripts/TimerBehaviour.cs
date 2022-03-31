using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimerBehaviour : MonoBehaviour
{
    public float timeLimit;

    public static Action<float> SendTime = delegate { };

    public delegate void Tests();
    public static event Tests test;

    private Text _text;

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<Text>();
        _text.text = "Time:"+((int)timeLimit);
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = "Time:" + ((int)timeLimit+1);
    }

    private void OnGUI()
    {
        if (timeLimit < 0)
        {
            //SendTime(timeLimit);
            if (test != null)
                test();
        }
    }

    private void FixedUpdate()
    {
        timeLimit = timeLimit - Time.fixedDeltaTime;        
    }
}
