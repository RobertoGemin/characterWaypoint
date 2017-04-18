using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
      public class AICharacterControl : MonoBehaviour{
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }          
        public ThirdPersonCharacter character { get; private set; }
        WayPointCharacter waypoint; //{ get; private set; }
        public Transform target; 
        public int waypointId;
        public bool checkNextTarget;
        public float distance;
       

    private void Start(){
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();
            waypoint =  GetComponent<WayPointCharacter>();
            agent.updateRotation = false;
	        agent.updatePosition = true;         
            waypointId = 0;
            waypoint.goToNextTarget(waypointId);
            checkNextTarget = true;

        }

        private void OnCollisionEnter(Collision collision)
        {

        Debug.Log(collision.ToString() + " other");
        
            }

        private void OnTriggerEnter(Collider other)
        {
           
                if (other.name == "pos") {
                    other.gameObject.SetActive(false);
                    waypointId = waypoint.posWaypoint.Length == waypointId ? 0 : waypointId;
                    waypoint.goToNextTarget(waypointId++);
                    //checkNextTarget = false;
                 }
      
            if (other.name == "speed")
            {
                if (agent.speed == 1) {
                    agent.speed = (UnityEngine.Random.Range(0.1f, 1.0f));
                }
                else
                {
                    agent.speed = 1.0f;
                }


       

            }


        }


        private void Update(){
            if (target != null){
                agent.SetDestination(target.position);
            }
          

            if (agent.remainingDistance > agent.stoppingDistance){
                character.Move(agent.desiredVelocity, false, false);
               

            }

            else {
                character.Move(Vector3.zero, false, false);
                checkNextTarget = true;

            }
        }
        public void SetTarget(Transform target){
            this.target = target;
            this.target.gameObject.SetActive(true);
            distance = agent.remainingDistance;


        }
      
    }
}
