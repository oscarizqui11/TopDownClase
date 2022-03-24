using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public int playerPosyOffset;

    // Start is called before the first frame update
    private void Awake()
    {
        GetComponent<MovementBehavior>().velocity = player.GetComponent<MovementBehavior>().velocity;
    }
}
