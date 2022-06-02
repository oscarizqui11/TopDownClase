using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    public GameObject EnemyUnits;
    public float minDelayEnemy;
    public float maxDelayEnemy;

    private float delayEnemy;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        delayEnemy = Random.Range(minDelayEnemy, maxDelayEnemy);
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        
        if(time >= delayEnemy)
        {
            time = 0;

            Instantiate(EnemyUnits, transform.position, Quaternion.identity);

            delayEnemy = Random.Range(minDelayEnemy, maxDelayEnemy);
        }
    }
}
