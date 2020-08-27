using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    Vector3 destination;
    NavMeshAgent agent;
    //Ray is an invisible line between the game's viewpoint origin (main camera origin) 
    //and a point on the screen.
    Ray lastRay;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            MoveToCursor();
        }
        UpdateAnimator();
    }
    private void MoveToCursor()
    {
        ///Out keyword is used to retrieve information out from a method and store in
        ///a variable. RaycastHit is used to hold the information needed, to know where
        ///the cursor has clicked in world space
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInformation;
        bool hasHit =  Physics.Raycast(ray, out hitInformation);
        if (hasHit)
        {
            agent.destination = hitInformation.point;
        }
    }
    private void UpdateAnimator()
    {
        ///InverseTransformDirection takes a world space velocity and converts it into a local velocity
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        GetComponent<Animator>().SetFloat("forwardSpeed", speed);
    }
}
