using UnityEngine;
using System.Collections.Generic;

public class WaypointManager : MonoBehaviour
{

    public List<Transform> wayPoints = new List<Transform>();
    public bool isMoving;
    public int waypointIndex;
    public float moveSpeed;
    public float rotationSpeed; 

    void Start()
    {
        StartMoving();
    }

    public void StartMoving()
    {
        waypointIndex = 0;
        isMoving = true;
    }

    void Update()
    {
        if (!isMoving)
        {
            return;
        }

        if (waypointIndex < wayPoints.Count)
        {
            transform.position = Vector3.MoveTowards(transform.position, target: wayPoints[waypointIndex].position, maxDistanceDelta: Time.deltaTime * moveSpeed);

            var direction = transform.position - wayPoints[waypointIndex].position;
            var targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed); 

            var distance = Vector3.Distance(transform.position, wayPoints[waypointIndex].position);

            if (distance <= 0.05f)
            {
                waypointIndex++;
            }
        }

    }
}
