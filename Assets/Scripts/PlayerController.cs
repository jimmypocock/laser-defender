using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 15.0f;
	public float padding = 0.5f;

	private float minX;
	private float maxX;

	private float minY;
	private float maxY;

	void Start () {
		FindViewportEdges ();
	}

	void Update () {
		MoveShip ();

		// Restrict player to game space.
		float newX = Mathf.Clamp ( transform.position.x, minX, maxX );
		float newY = Mathf.Clamp ( transform.position.y, minY, maxY );
		transform.position = new Vector3 ( newX, newY, transform.position.z );
	}

	void FindViewportEdges () {

		// Distance between camera and object in 3D world.
		float distance = transform.position.z - Camera.main.transform.position.z;

		Vector3 leftMost = Camera.main.ViewportToWorldPoint ( new Vector3 ( 0, 0, distance ) );
		Vector3 rightMost = Camera.main.ViewportToWorldPoint ( new Vector3 ( 1, 0, distance ) );

		minX = leftMost.x + padding;
		maxX = rightMost.x - padding;

		Vector3 bottomMost = Camera.main.ViewportToWorldPoint ( new Vector3 ( 0, 0, distance ) );
		Vector3 topMost = Camera.main.ViewportToWorldPoint ( new Vector3 ( 0, 1, distance ) );

		minY = bottomMost.y + padding;
		maxY = topMost.y - padding;
	}

	void MoveShip () {

		if ( Input.GetKey( KeyCode.LeftArrow ) ) {
//			transform.position += new Vector3 ( -speed * Time.deltaTime, 0, 0 );
			transform.position += Vector3.left * speed * Time.deltaTime;

		} else if ( Input.GetKey ( KeyCode.RightArrow ) ) {
//			transform.position += new Vector3 ( speed * Time.deltaTime, 0, 0 );
			transform.position += Vector3.right * speed * Time.deltaTime;
		}

		if ( Input.GetKey( KeyCode.UpArrow ) ) {
//			transform.position += new Vector3 ( 0, speed * Time.deltaTime, 0 );
			transform.position += Vector3.up * speed * Time.deltaTime;

		} else if ( Input.GetKey ( KeyCode.DownArrow ) ) {
//			transform.position += new Vector3 ( 0, -speed * Time.deltaTime, 0 );
			transform.position += Vector3.down * speed * Time.deltaTime;
		}
	}
}
