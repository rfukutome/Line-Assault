using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour {

    public ParticleEmitter particle_emitter;
    private int player_respawn_time;
    private PlayerMovement player_movement;
    string player_color; //future use?

	// Use this for initialization
	void Start () {
        player_movement = gameObject.GetComponentInParent<PlayerMovement>();
        player_respawn_time = 5;
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(this.gameObject);
    }

    void OnParticleCollision(GameObject other)
    {
        PlayerDeath();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
    }

    void PlayerDeath()
    {
        //Making all powerups zero.
        //Make the player stop moving.
        player_movement.PlayerDeath();
        StartCoroutine(DeathAnimation());
    }

    IEnumerator DeathAnimation()
    {
        yield return new WaitForSeconds(player_respawn_time);
        //TODO Should play a respawn animation...count down?
        Destroy(this.gameObject);
        player_movement.PlayerRespawn();
    }
}
