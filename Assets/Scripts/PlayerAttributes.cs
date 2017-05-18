using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour {

    public ParticleSystem.MainModule particle_system;
    private int player_respawn_time = 3;
    private PlayerMovement player_movement;
    private SpriteRenderer sprite_renderer;
    private Color player_color; //future use?

	// Use this for initialization
	void Start () {
        player_movement = gameObject.GetComponentInParent<PlayerMovement>();
        sprite_renderer = gameObject.GetComponent<SpriteRenderer>();
        particle_system = transform.parent.GetComponentInChildren<ParticleSystem>().main;
        PickRandomColor();
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

    void PickRandomColor()
    {
        float red_float = 0;
        float blue_float = 0;
        float green_float = 0;

        bool red_picked = false;
        bool blue_picked = false;
        bool green_picked = false;


        int number_direction = Random.Range(0, 3);

        switch (number_direction)
        {
            case 0:
                red_float = 255f;
                red_picked = true;
                break;
            case 1:
                blue_float = 255f;
                blue_picked = true;
                break;
            case 2:
                green_float = 255f;
                green_picked = true;
                break;
            default:
                Debug.Log("ERROR: PickRandomColor(), switch case 1");
                break;
        }



        bool second_color_picked = false;

        while (second_color_picked == false)
        {
            number_direction = Random.Range(0, 3);
            switch (number_direction)
            {
                case 0:
                    if (!red_picked)
                    {
                        red_float = Random.Range(0, 255);
                        second_color_picked = true;
                    }
                    break;
                case 1:
                    if (!blue_picked)
                    {
                        blue_float = Random.Range(0, 255);
                        second_color_picked = true;
                    }
                    break;
                case 2:
                    if (!green_picked)
                    {
                        green_float = Random.Range(0, 255);
                        second_color_picked = true;
                    }
                    break;
                default:
                    Debug.Log("ERROR: PickRandomColor(), switch case 2");
                    break;
            }
        }

        Debug.Log("R: " + red_float + ", G: " + green_float + ", B: " + blue_float);
        player_color = new Color(red_float/255.0f, green_float / 255.0f, blue_float / 255.0f, 1.0f);
        sprite_renderer.color = player_color;
        particle_system.startColor = player_color;
        
    }

    IEnumerator DeathAnimation()
    {
        yield return new WaitForSeconds(player_respawn_time);
        //TODO Should play a respawn animation...count down?
        Destroy(this.gameObject);
        player_movement.PlayerRespawn();
    }
}
