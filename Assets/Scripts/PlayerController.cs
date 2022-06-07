using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int spriteRotation;
    public Vector3 spawnPosition;

    private Animator _anim;
    private SpriteRenderer _sprt;
    private MovementBehavior _mv;
    private static Camera mainCamera;

    public Vector3 direction;
    private Vector3 cameraDir;

    private ShootingBehaviour _shb;

    private bool invincible = false;
    public float invincibilityTime;
    private float invincibilityTimer;

    // Start is called before the first frame update
    void Awake()
    {
        _anim = GetComponent<Animator>();
        _sprt = GetComponent<SpriteRenderer>();
        _mv = GetComponent<MovementBehavior>();
        _shb = GetComponent<ShootingBehaviour>();
        mainCamera = Camera.main;
    }
    
    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        direction = new Vector3(hor, ver);

        if (ver > 0.1 || hor > 0.1 ||
            ver < -0.1 || hor < -0.1)
        {
            _anim.SetInteger("State", 1);
            _anim.SetBool("IsWalking", true);
            _mv.RotateDirection(direction.normalized, spriteRotation);
            
        }
        else
        {
            _anim.SetInteger("State", 0);
            _anim.SetBool("IsWalking", false);
        }

        if(Input.GetButtonDown("Fire1") && !_shb.shooted)
        {
            _anim.SetInteger("State", 2);
            _shb.Shoot();
            //GetComponent<ShootingBehaviour>().shooted = true;
        }
        else
        {
            _anim.SetInteger("State", 0);
            _shb.shooted = false;
        }

    }

    private void FixedUpdate()
    {
        _mv.MoveRB(direction.normalized);

        cameraDir.y = direction.normalized.y;
        if(cameraDir.y > 0 && transform.position.y >= mainCamera.transform.position.y + mainCamera.GetComponent<CameraController>().playerPosyOffset)
        {
            mainCamera.GetComponent<MovementBehavior>().MoveTowards(cameraDir);
        }

        if (invincible)
        {
            if (invincibilityTimer >= 0)
            {
                invincibilityTimer -= Time.fixedDeltaTime;
            }
            else
            {
                invincible = false;
                _anim.SetLayerWeight(2, 0);
            }
        }
    }

    public void Respawn()
    {
        transform.position = new Vector3(mainCamera.transform.position.x + spawnPosition.x, mainCamera.transform.position.y + spawnPosition.y, 0);
        invincible = true;
        invincibilityTimer = invincibilityTime;
        _anim.SetLayerWeight(2, 1);
    }

    public bool IsInvincible()
    {
        return invincible;
    }
}
