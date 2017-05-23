using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Transform player_transform;
	// Use this for initialization

	
	// Update is called once per frame
	void LateUpdate () {
        if(player_transform != null)
        {
            Vector3 temp_vector = new Vector3(player_transform.position.x, player_transform.position.y, this.transform.position.z);
            this.transform.position = temp_vector;
        }

	}

    public void FindPlayerTransform()
    {
        player_transform = GameObject.FindGameObjectWithTag("OwnPlayer").transform;
    }
}
