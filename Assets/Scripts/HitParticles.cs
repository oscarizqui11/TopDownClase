using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitParticles : MonoBehaviour
{
    private Animator _anim;
    private float animTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(animTimer >= _anim.GetCurrentAnimatorStateInfo(0).length)
        {
            animTimer = 0;
            gameObject.SetActive(false);
        }
        else
        {
            animTimer += Time.fixedDeltaTime;
        }
    }
}
