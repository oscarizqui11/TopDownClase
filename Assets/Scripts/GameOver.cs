using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.sendGameOver += FinishGame;
    }

    private void OnDisable()
    {
        EventManager.sendGameOver -= FinishGame;
    }

    private void FinishGame()
    {
        Debug.Log("Game Over Event!");
    }
}
