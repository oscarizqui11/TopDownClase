using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBehaviour : MonoBehaviour
{
    public static Transform[] mapsList;

    public float tileDistanceOffset;

    private Transform lowestMapTile;
    private Transform topMapTile;
    private static Camera mainCamera;

    private void Awake()
    {
        mapsList = GetComponentsInChildren<Transform>();
        lowestMapTile = GetLowestMapTile();
        topMapTile = GetTopMapTile();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (lowestMapTile.position.y + lowestMapTile.GetComponent<SpriteRenderer>().size.y / 2 < mainCamera.transform.position.y - 2f * mainCamera.orthographicSize / 2f)
        {
            AdvanceMap();
        }
    }

    private void AdvanceMap()
    {
        lowestMapTile.position += new Vector3(0,topMapTile.position.y - lowestMapTile.position.y + topMapTile.GetComponent<SpriteRenderer>().size.y / 2 + lowestMapTile.GetComponent<SpriteRenderer>().size.y / 2 + tileDistanceOffset);

        lowestMapTile = GetLowestMapTile();
        topMapTile = GetTopMapTile();
    }

    private Transform GetLowestMapTile()
    {
        Transform ret = mapsList[1];

        int i = 2;

        while(i < mapsList.Length)
        {
            if(mapsList[i].position.y < ret.position.y)
            {
                ret = mapsList[i];
            }

            i++;
        }

        return ret;
    }

    private Transform GetTopMapTile()
    {
        Transform ret = mapsList[1];

        int i = 2;

        while (i < mapsList.Length)
        {
            if (mapsList[i].position.y > ret.position.y)
            {
                ret = mapsList[i];
            }

            i++;
        }

        return ret;
    }
}
