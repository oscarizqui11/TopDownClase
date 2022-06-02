using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPoints : MonoBehaviour
{
    public Vector3 initialPos;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = GetComponent<Transform>().position;
    }
}
