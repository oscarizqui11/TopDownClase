using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    Vector3 direction;
    public int damage;
    public int spriteRotation;
    public string soundPrefab;

    private SpriteRenderer _spr;

    private static Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        _spr = GetComponent<SpriteRenderer>();
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

        GameObject newSoundFX = PoolingManager.Instance.GetPooledObject(soundPrefab);
        if(newSoundFX != null)
        {
            newSoundFX.transform.position = transform.position;
            newSoundFX.SetActive(true);
            newSoundFX.GetComponent<AudioSource>().Play();
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<HealthBehaviour>().TakeDamage(damage);
        Destroy(gameObject);
    }*/

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<HealthBehaviour>(out HealthBehaviour target))
        {
            target.TakeDamage(damage);
            gameObject.SetActive(false);
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<HealthBehaviour>(out HealthBehaviour target))
        {
            target.TakeDamage(damage);
            gameObject.SetActive(false);
        }
    }*/

    private void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
