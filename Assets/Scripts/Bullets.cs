using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    Vector3 direction;
    public int damage;
    public int spriteRotation;

    private static Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<MovementBehavior>().MoveRB(direction);
    }

    public void SetTarget(Vector3 targetDir)
    {
        direction = targetDir;
        direction.Normalize();
        GetComponent<MovementBehavior>().RotateDirection(direction, spriteRotation);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<HealthBehaviour>().TakeDamage(damage);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<HealthBehaviour>().TakeDamage(damage);
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
