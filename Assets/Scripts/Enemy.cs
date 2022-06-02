using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector3 nextPointDir;

    
    public GameObject player;

    public int pointsReward;
    public int atkDamage;
    public float attackDistance;
    public float attackDelay;
    public float shotDistance;
    public float shotSpeed;
    public int spriteRotation;

    private MovementBehavior mv;
    private Animator _anim;
    private Rigidbody2D _rb2d;
    private SpriteRenderer _sprt;
    private ShootingBehaviour _shb;
    private float shotTimer;
    private bool isWalking;
    private bool isAttacking;

    
    private Vector3 playerDeath;

    // Start is called before the first frame update
    void Start()
    {
        mv = GetComponent<MovementBehavior>();
        _anim = GetComponent<Animator>();
        _rb2d = GetComponent<Rigidbody2D>();
        _sprt = GetComponent<SpriteRenderer>();
        _shb = GetComponent<ShootingBehaviour>();
        player = GameObject.Find("Survivor");
        playerDeath = player.transform.position;
        nextPointDir = player.transform.position - transform.position;
        nextPointDir.Normalize();
        mv.RotateDirection(nextPointDir, 0);
        shotTimer = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        _sprt.sortingOrder = (int)((transform.position.y - Camera.main.transform.position.y) * -100);
    }

    private void FixedUpdate()
    {
        if(player != null)
        {
            playerDeath = player.transform.position;
        }

        nextPointDir = playerDeath - transform.position;        
        
            
        if(IsInShotDistance() && transform.position.y > playerDeath.y)
        {
            if(shotTimer >= shotSpeed)
            {
                _anim.SetTrigger("Shot");
                _shb.Shoot();
                shotTimer = 0;
            }
            else
            {
                shotTimer += Time.fixedDeltaTime;
                _anim.SetBool("Walk", false);
                _anim.SetBool("Attack", false);
            }

        }
        else
        {
            //nextPointDir.Normalize();
            if (!IsPlayerReached())
            {
                _anim.SetBool("Walk", true);
                _anim.SetBool("Attack", false);
                nextPointDir.Normalize();
                mv.MoveTowards(nextPointDir);
            }
            else
            {
                _anim.SetBool("Walk", false);
                _anim.SetBool("Attack", true);
            }
            nextPointDir.Normalize();
            mv.RotateDirection(nextPointDir, 0);
        }
        
    }

    private bool IsPlayerReached()
    {
        return Vector3.Distance(transform.position, playerDeath) <= attackDistance;
    }

    private bool IsInShotDistance()
    {
        return Vector3.Distance(transform.position, playerDeath) >= shotDistance;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _rb2d.velocity = new Vector2 (_rb2d.velocity.x * 0.3f, _rb2d.velocity.y * 0.3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<PlayerController>(out PlayerController target))
        {
            target.GetComponent<HealthBehaviour>().TakeDamage(atkDamage);
        }
    }

    /*private Vector3 NextPosition()
    {
        return transform.position + nextPointDir * mv.velocity * Time.fixedDeltaTime;
    }
    
    private void OnDestroy()
    {
        if (gameObject.GetComponent<HealthBehaviour>().health <= 0)
        {
            FindObjectOfType<Player>().points += pointsReward;
        }
        EnemyGenerator.listEnemies.Remove(gameObject);
    }*/
}
