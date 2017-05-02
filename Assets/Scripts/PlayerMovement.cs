using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private enum Direction
    {
        UP = 0,
        RIGHT = 1,
        DOWN = 2,
        LEFT = 3,
        NONE = 4
    };

    private float max_player_speed = 6;
    private float player_speed;
    private bool after_first_input;
    private Direction direction;
	
    // Use this for initialization
	void Start () {
        after_first_input = false;
        direction = Direction.NONE;
        player_speed = 0;
	}
	
	// Update is called once per frame
	void Update () {
        float input_x = Input.GetAxis("Horizontal");
        float input_y = Input.GetAxis("Vertical");
        Vector2 input_direction = new Vector2(input_x, input_y);

        //Get which direction:
        float input_angle = Mathf.Atan(input_y / input_x);

        //If you're not moving, take any direction
        if (!after_first_input && input_direction != Vector2.zero)
        {
            PickRandomDirection();
            after_first_input = true;
        }

        switch (direction)
        {
            case Direction.UP:
                transform.Translate(new Vector3(0, 1) * Time.deltaTime * max_player_speed);
                break;
            case Direction.RIGHT:
                transform.Translate(new Vector3(1, 0) * Time.deltaTime * max_player_speed);
                break;
            case Direction.DOWN:
                transform.Translate(new Vector3(0, -1) * Time.deltaTime * max_player_speed);
                break;
            case Direction.LEFT:
                transform.Translate(new Vector3(-1, 0) * Time.deltaTime * max_player_speed);
                break;
            case Direction.NONE:
                break;
        }
    }

    void PickRandomDirection()
    {
        int number_direction = Random.Range(0, 3);

        switch (number_direction)
        {
            case 0:
                direction = Direction.UP;
                break;
            case 1:
                direction = Direction.RIGHT;
                break;
            case 2:
                direction = Direction.DOWN;
                break;
            case 3:
                direction = Direction.LEFT;
                break;
        }
        Debug.Log(direction);

    }
}
