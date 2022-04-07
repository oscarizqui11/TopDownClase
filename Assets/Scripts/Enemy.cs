using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector3 nextPointDir;
    public GameObject player;
    public int pointsReward;
    public float attackDistance;
    public float attackDelay;

    private MovementBehavior mv;
    private Animator _anim;
    private Rigidbody2D _rb2d;
    private SpriteRenderer _sprt;
    private float atkTimer;
    private bool isWalking;
    private bool isAttacking;

    // Start is called before the first frame update
    void Start()
    {
        mv = GetComponent<MovementBehavior>();
        _anim = GetComponent<Animator>();
        _rb2d = GetComponent<Rigidbody2D>();
        _sprt = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Survivor");
        nextPointDir = player.transform.position - transform.position;
        nextPointDir.Normalize();
        mv.RotateDirection(nextPointDir, 0);
    }

    // Update is called once per frame
    private void Update()
    {
        _sprt.sortingOrder = (int)((transform.position.y - player.transform.position.y) * -100);
    }

    private void FixedUpdate()
    {
        nextPointDir = player.transform.position - transform.position;
        if (player != null)
        {
            //nextPointDir.Normalize();
            if (!IsPositionReached())
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
        else
        {
            _anim.SetBool("Walk", false);
            _anim.SetBool("Attack", false);
        }
    }

    private bool IsPositionReached()
    {
        return Vector3.Distance(transform.position, player.transform.position) <= attackDistance;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _rb2d.velocity = new Vector2 (_rb2d.velocity.x * 0.4f, _rb2d.velocity.y * 0.4f);
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
