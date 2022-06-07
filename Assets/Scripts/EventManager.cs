using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager current;

    private void Awake()
    {
        current = this;
    }

    public delegate void SendGameOver();
    public static event SendGameOver sendGameOver;

    private void Update()
    {
        if (sendGameOver != null)
            sendGameOver();
    }

}
