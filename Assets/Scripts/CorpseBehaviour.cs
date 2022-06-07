using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorpseBehaviour : MonoBehaviour
{
    public float corpseTime;
    private float corpseTimer;

    // Start is called before the first frame update
    void Start()
    {
        corpseTimer = corpseTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (corpseTimer >= 0)
        {
            corpseTimer -= Time.fixedDeltaTime;
        }
        else
        {
            corpseTimer = corpseTime;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject newBloodSplash = PoolingManager.Instance.GetPooledObject("Headshot");

        newBloodSplash.transform.position = transform.position;
        newBloodSplash.SetActive(true);
    }
}
