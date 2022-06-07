using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tests : MonoBehaviour
{
    private float timer;
    private bool hasToEat;

    private void OnEnable()
    {
        TimerBehaviour.SendTime += getTime;
        Enemy.EatCorpse += aimCorpse;
        TimerBehaviour.test += Esparta;
    }

    private void OnDisable()
    {
        TimerBehaviour.SendTime -= getTime;
        Enemy.EatCorpse -= aimCorpse;
        TimerBehaviour.test -= Esparta;
    }

    private void Esparta()
    {
        SceneManager.LoadScene(3);
    }

    private void getTime(float t)
    {
        timer = t;
    }

    private void aimCorpse(bool d)
    {
        hasToEat = d;
    }
}
