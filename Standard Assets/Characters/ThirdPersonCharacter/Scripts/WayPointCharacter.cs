using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class WayPointCharacter : MonoBehaviour {
        public Transform[] posWaypoint;
        public GameObject setTargetOn;
        public int newId;
        public void goToNextTarget(int id){
            setTargetOn.SendMessage("SetTarget", posWaypoint[id]);
            newId = id;
            //Debug.Log(id.ToString() + " " + posWaypoint.Length.ToString());
        }
    }

}