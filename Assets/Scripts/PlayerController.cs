using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed = 4.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
        //Vector to store change in movement.
	    var move = new Vector3();

        /*
         * Movement:
         * Player moves using the WASD keys. 
         */

        if (Input.GetKey(KeyCode.A))
        {
            move += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            move += Vector3.right;
        }
        if (Input.GetKey(KeyCode.W))
        {
            move += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            move += Vector3.down;
        }

	    transform.position += move * speed * Time.deltaTime;
	}
}
