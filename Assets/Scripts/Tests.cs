using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tests : MonoBehaviour
{
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        TimerBehaviour.SendTime += getTime;
        TimerBehaviour.test += Esparta;
    }

    private void OnDisable()
    {
        TimerBehaviour.SendTime -= getTime;
        TimerBehaviour.test -= Esparta;
    }

    private void Esparta()
    {
        Debug.Log("GAME OVER!");
    }

    private void getTime(float t)
    {
        timer = t;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
