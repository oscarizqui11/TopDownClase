using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    public GameObject EnemyUnits;
    public TimerBehaviour _timer;
    public float minDelayEnemy;
    public float maxDelayEnemy;

    private float delayEnemy;
    private float time;
    private PlayerController _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<PlayerController>();
        delayEnemy = Random.Range(minDelayEnemy, maxDelayEnemy);
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        
        if(time >= delayEnemy + _timer.timeLimit / 100 && _player.gameObject.activeInHierarchy)
        {
            time = 0;

            Instantiate(EnemyUnits, transform.position, Quaternion.identity);

            delayEnemy = Random.Range(minDelayEnemy, maxDelayEnemy);
        }
    }
}
