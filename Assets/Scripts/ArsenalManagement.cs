using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Weapon
{
    public string Name;
    public float weapCadency;
    public string bulletType;
    public AudioClip clipSource;
}

public class ArsenalManagement : MonoBehaviour
{
    private Animator _anim;
    private SpriteRenderer _sprt;

    [SerializeField]
    private List<Weapon> arsenalWapons = new List<Weapon>();

    // Start is called before the first frame update
    void Awake()
    {
        _anim = GetComponent<Animator>();
        _sprt = GetComponent<SpriteRenderer>();
        GetComponent<AudioSource>().clip = arsenalWapons[0].clipSource;
    }

    void Update()
    {
        if (Input.GetButtonDown("Arsenal_0"))
        {
            _anim.SetLayerWeight(1, 0);
            GetComponent<AudioSource>().clip = arsenalWapons[0].clipSource;
        }
        else if (Input.GetButtonDown("Arsenal_1"))
        {
            _anim.SetLayerWeight(1, 1);
            GetComponent<AudioSource>().clip = arsenalWapons[1].clipSource;
        }
    }
}
