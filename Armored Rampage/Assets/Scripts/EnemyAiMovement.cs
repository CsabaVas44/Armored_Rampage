using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{
    class EnemyAiMovement : MonoBehaviour
    {
        NavMeshAgent agent;
        public Transform[] waypoints;
        int waypointIndex;
        Vector3 target;

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (Vector3.Distance(transform.position, target) < 1)
            {
                IterateWaypointIndex();
                UpdateDestination();
            }
        }

        void UpdateDestination()
        {
            target = waypoints[waypointIndex].position;
            agent.SetDestination(target);

        }
        void IterateWaypointIndex()
        {
            waypointIndex++;
            if (waypointIndex == waypoints.Length)
            {
                waypointIndex = 0;
            }
        }
    }


}
