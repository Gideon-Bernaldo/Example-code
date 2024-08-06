using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using PixKeeper.Events;

public class PlayerMove : MonoBehaviour
{
    NavMeshAgent agent;
    NavMeshPath path;
    Camera camera_;

    bool sit = false;

    private void Awake()
    {
        EventsOfWorld.satDown += SatDown;
    }

    private void OnDestroy()
    {
        EventsOfWorld.satDown -= SatDown;
    }

    private void Start()
    {
        camera_ = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
    }

    private void LateUpdate()
    {
        SetTarget();
    }

    void SatDown(bool status)
    {
        sit = status;
        agent.enabled = !sit;
    }

    void SetTarget()
    {
        if(Input.GetMouseButtonDown(1) && !sit)
        {           
            Ray ray = camera_.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, 1000))
            {
                agent.CalculatePath(hitInfo.point, path);

                if(path.status == NavMeshPathStatus.PathComplete)
                {
                    EventsOfMouse.OnGoalAccessStatus(hitInfo.point, true);
                    agent.SetDestination(hitInfo.point);
                }
                else EventsOfMouse.OnGoalAccessStatus(hitInfo.point, false);
            }
        }
    }
}
