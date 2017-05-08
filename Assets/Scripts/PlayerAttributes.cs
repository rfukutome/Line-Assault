using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour {

    string player_color; //future use?

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("we're hit!");
        Destroy(this.gameObject);
    }

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("We hit the particles!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("we're hit!");
        Destroy(this.gameObject);
    }
}
