using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{
    // Enumeration for different states of the enemy
    public enum EnemyState { Patrol, ChasePlayer, AttackPlayer }; //{0,1,2}
    public EnemyState currentState;

    // Reference to the sight sensor component
    public Sight sightSensor;

    // Reference to the NavMeshAgent component
    private NavMeshAgent agent;

    // Reference to the bullet prefab to be instantiated when attacking
    public GameObject bulletPrefab;

    // Variables for shooting rate and timing
    public float lastShootTime;
    public float fireRate;

    // Distance at which the enemy attacks the player
    public float playerAttackDistance;

    // Rotation speed for smoother rotations
    public float rotationSpeed = 5f;

    public List<Transform> wayPoints = new List<Transform>(); //List to hold waypoints
    private int currentWayPointIndex = 0;

    // Method to make the enemy look at a specified position
    void LookTo(Vector3 targetPosition)
    {
        Vector3 directionToPosition = Vector3.Normalize(targetPosition - transform.parent.position);
        directionToPosition.y = 0;
        transform.parent.forward = directionToPosition;
    }

    // Awake method is called when the script instance is being loaded
    private void Awake()
    {
        // Get the NavMeshAgent component from the parent GameObject
        agent = GetComponentInParent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check the current state of the enemy and execute corresponding behavior
        if (currentState == EnemyState.Patrol)
        {
            Patroling();
            print("Patroling");
        }
        else if (currentState == EnemyState.ChasePlayer)
        {
            ChasePlayer();
            print("Chasing Player");
        }
        else
        {
            AttackPlayer();
            print("Attacking Player");
        }
    }

    // Method for the patrolling behavior
    void Patroling()
    {
        //Return if there are no waypoints
        if(wayPoints.Count == 0){
            return;
        }
        //Move towards the waypoint
        agent.SetDestination(wayPoints[currentWayPointIndex].position);

        //Calculate distance to the currentWayPoint
        float distanceToWayPoint = Vector3.Distance(transform.position,wayPoints[currentWayPointIndex].position);
        //Debug.Log("Distance to WayPoint: " + distanceToWayPoint);

        //Check if we have reached the current waypoint
        if(distanceToWayPoint < 2f){
            //Debug.Log("Reached WayPoint: " + currentWayPointIndex);

            //move to the next waypoint in the list
            currentWayPointIndex++;
            if(currentWayPointIndex >= wayPoints.Count){
                currentWayPointIndex =0; //loop back to the first waypoint
            }
        }
        

        // Check for player detection
        if (sightSensor.detectedObject != null)
        {
            currentState = EnemyState.ChasePlayer;
        }
    }   

    // Method for chasing the player
    void ChasePlayer()
    {
        // Allow the NavMeshAgent to move
        agent.isStopped = false;

        // If the player is no longer detected, switch back to patrol state
        if (sightSensor.detectedObject == null)
        {
            currentState = EnemyState.Patrol;
            return;
        }

        // Move towards the detected player using NavMeshAgent
        agent.SetDestination(sightSensor.detectedObject.transform.position);

        // Calculate the distance to the player
        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);

        // If the player is within attack distance, switch to AttackPlayer state
        if (distanceToPlayer <= playerAttackDistance)
        {
            currentState = EnemyState.AttackPlayer;
        }
    }

    // Method for attacking the player
    void AttackPlayer()
    {
        // Stop the NavMeshAgent from moving
        agent.isStopped = true;

        // Make the enemy look at the player
        LookTo(sightSensor.detectedObject.transform.position);

        // Shoot at the player
        Shoot();

        // If the player is no longer detected, switch back to patrol state
        if (sightSensor.detectedObject == null)
        {
            currentState = EnemyState.Patrol;
            return;
        }

        // Calculate the distance to the player
        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);

        // If the player is out of attack range, switch to ChasePlayer state
        if (distanceToPlayer > playerAttackDistance * 1.1)
        {
            currentState = EnemyState.ChasePlayer;
        }
    }

    // Method for shooting at the player
    void Shoot()
    {
        // Calculate the time since the last shot
        var timeSinceLastShoot = Time.time - lastShootTime;

        // If enough time has passed, shoot and update the last shoot time
        if (timeSinceLastShoot > fireRate)
        {
            lastShootTime = Time.time;
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }

    // Gizmos for visualizing attack distance
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, playerAttackDistance);
    }
}

