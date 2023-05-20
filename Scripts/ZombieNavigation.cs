using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieNavigation : MonoBehaviour
{
    private Transform playerTransform;
    private NavMeshPath path;
    private GameObject cube;

    private void Awake()
    {
        GetComponent<Health>().OnDied += ZombieNavigation_OnDied;
    }

    private void ZombieNavigation_OnDied()
    {
        this.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        path = new NavMeshPath();
        //cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //cube.GetComponent<Collider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        var targetPosition = playerTransform.position;

        bool foundPath = NavMesh.CalculatePath(transform.position, targetPosition, NavMesh.AllAreas, path);
        if(foundPath)
        {
            Vector3 nextDestination = path.corners[1];
            //cube.transform.position = nextDestination;

            Vector3 directionToTarget = nextDestination - transform.position;
            Vector3 flatDirection = Vector3.Normalize(new Vector3(directionToTarget.x, 0, directionToTarget.z));

            var desiredRotation = Quaternion.LookRotation(flatDirection);
            var finalRotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime);
            transform.rotation = finalRotation;
        }
    }
}
