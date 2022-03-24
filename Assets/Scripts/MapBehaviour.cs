using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBehaviour : MonoBehaviour
{
    public static Transform[] mapsList;

    private void Awake()
    {
        mapsList = GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            AdvanceMap();
        }
    }

    private void AdvanceMap()
    {
        //Debug.Log(mapsList[0].position);
        mapsList[1].position += new Vector3(0, mapsList[2].position.y + mapsList[2].GetComponent<SpriteRenderer>().size.y / 2);
    }

    private void GetLowerMapTile()
    {
        
    }
}
