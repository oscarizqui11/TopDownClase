using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBehaviour : MonoBehaviour
{
    public float cadency;
    public GameObject SpitPool;
    public string shotType;
    public Vector3 gunPosition;
    public bool shooted;

    private float time;
    private Vector3 spriteDirection;

    private void Awake()
    {
        int playerSprtAngle = GetComponent<PlayerController>().spriteRotation;
        spriteDirection = new Vector3(Mathf.Cos(playerSprtAngle), Mathf.Sin(playerSprtAngle));
    }

    public void Shoot()
    {
        if (time >= cadency)
        {
            GameObject newBullet = PoolingManager.Instance.GetPooledObject(shotType);
            
            if(newBullet != null && time >= cadency)
            {
                time = 0;
                newBullet.transform.position = transform.position + transform.rotation * gunPosition;
                newBullet.GetComponent<Bullets>().SetTarget(transform.rotation * spriteDirection);
                newBullet.SetActive(true);
                shooted = true;
            }
        }
    }

    private void FixedUpdate()
    {
        time = time + Time.deltaTime;
    }
}
