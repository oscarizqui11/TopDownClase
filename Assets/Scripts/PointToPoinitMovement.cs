using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToPoinitMovement : MonoBehaviour
{
    public Transform[] _points;
    private MovementBehavior _mv;

    private int pointIndex;
    public Vector3 nextPointDir;

    // Start is called before the first frame update
    void Start()
    {
        _mv = GetComponent<MovementBehavior>();

        pointIndex = 0;

        nextPointDir = _points[pointIndex].transform.position - transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!IsPositionReached())
        {
            _mv.MoveTowards(nextPointDir.normalized);
        }
        else
        {
            if (pointIndex == 0)
            {
                pointIndex = 1;
            }
            else if (pointIndex == 1)
            {
                pointIndex = 0;
            }

            nextPointDir = _points[pointIndex].transform.position - transform.position;
        }
    }
    public bool IsPositionReached()
    {
        return Vector3.Distance(transform.position, _points[pointIndex].transform.position) <= Vector3.Distance(NextPosition(), _points[pointIndex].transform.position);
    }

    private Vector3 NextPosition()
    {
        return transform.position + nextPointDir * _mv.velocity * Time.deltaTime;
    }
}
