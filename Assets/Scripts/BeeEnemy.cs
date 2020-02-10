using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeEnemy : Enemy
{
    public List<Vector2> FlightPath;
    public float Speed; 

    private int CurrentPathIndex = 0;
    private float PathSwitchThreshold = 0.01f;
    private Vector3 NextPosition;

    // Start is called before the first frame update
    void Start()
    {
        NextWaypoint();
    }
    void Update()
    {
        if ((transform.position - NextPosition).magnitude < PathSwitchThreshold)
        {
            NextWaypoint();
        }
        transform.position += (Vector3)Movement * Time.deltaTime * -Speed;

        if (Movement.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void NextWaypoint()
    {
        CurrentPathIndex = (CurrentPathIndex + 1) % FlightPath.Count;
        NextPosition = FlightPath[CurrentPathIndex];
        Movement = (transform.position - (Vector3)NextPosition).normalized;
    }
}
