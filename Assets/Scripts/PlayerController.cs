using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int spriteRotation;

    private Animator _anim;
    private SpriteRenderer _sprt;
    private MovementBehavior _mv;
    private static Camera mainCamera;

    public Vector3 direction;
    private Vector3 cameraDir;

    // Start is called before the first frame update
    void Awake()
    {
        _anim = GetComponent<Animator>();
        _sprt = GetComponent<SpriteRenderer>();
        _mv = GetComponent<MovementBehavior>();
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

        if(Input.GetButtonDown("Fire1") && !GetComponent<ShootingBehaviour>().shooted)
        {
            _anim.SetInteger("State", 2);
            GetComponent<ShootingBehaviour>().Shoot();
            //GetComponent<ShootingBehaviour>().shooted = true;
        }
        else
        {
            _anim.SetInteger("State", 0);
            GetComponent<ShootingBehaviour>().shooted = false;
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
        //mainCamera.GetComponent<MovementBehavior>().MoveTowards(new Vector3(0, direction.normalized.y));
    }
}
