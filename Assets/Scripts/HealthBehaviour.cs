using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class HealthBehaviour : MonoBehaviour
{
    public int maxHp;
    public int health;

    public string bloodType;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHp;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        if (gameObject.TryGetComponent<PlayerController>(out PlayerController player))
        {
            if (!player.IsInvincible())
            {
                GameObject newCorpse = PoolingManager.Instance.GetPooledObject("Corpse");

                newCorpse.transform.position = transform.position;
                newCorpse.transform.rotation = transform.rotation;
                newCorpse.SetActive(true);

                if (health - damage > 0)
                {
                    health = health - damage;
                    player.Respawn();
                }
                else
                {
                    health = 0;
                    player.gameObject.SetActive(false);
                    SceneManager.LoadScene(2);
                }
            }
        }
        else
        {
            GameObject newBloodSplash = PoolingManager.Instance.GetPooledObject(bloodType);

            newBloodSplash.transform.position = transform.position;
            newBloodSplash.SetActive(true);
            

            if (health - damage > 0)
            {
                health = health - damage;
            }
            else
            {
                health = 0;
                Destroy(gameObject);
            }
        }
    }
}
