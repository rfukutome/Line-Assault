using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class SetupLocalPlayer : NetworkBehaviour {

	// Use this for initialization
	void Start () {
        if (isLocalPlayer)
        {
            GetComponent<PlayerMovement>().enabled = true;
            transform.gameObject.tag = "OwnPlayer";
        }
        else
        {
            GetComponent<PlayerMovement>().enabled = false;
            transform.gameObject.tag = "OtherPlayer";
        }
	}
}
