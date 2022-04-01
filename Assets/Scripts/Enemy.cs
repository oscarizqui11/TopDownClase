using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector3 nextPointDir;
    public GameObject player;
    public int pointsReward;
    public float attackDistance;

    private MovementBehavior mv;
    private Animator _anim;
    private bool isWalking;
    private bool isAttacking;

    // Start is called before the first frame update
    void Start()
    {
        mv = GetComponent<MovementBehavior>();
        _anim = GetComponent<Animator>();
        nextPointDir = player.transform.position - transform.position;
        nextPointDir.Normalize();
        mv.RotateDirection(nextPointDir, 0);
    }

    // Update is called once per frame
   
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
                if(!_anim.GetBool("Attack"))
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
