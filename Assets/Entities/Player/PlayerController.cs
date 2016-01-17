using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed = 15.0f;
	public GameObject projectile;

	void Start ()
	{
	}

	void Update ()
	{
		MoveShip ();

		// Restrict player to game space.
		float restrictedX = Mathf.Clamp (transform.position.x, Viewport.minX, Viewport.maxX);
		float restrictedY = Mathf.Clamp (transform.position.y, Viewport.minY, (Viewport.minY + 3));

		transform.position = new Vector3 (restrictedX, restrictedY, transform.position.z);

		ShootLaser ();
	}


	void MoveShip ()
	{
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;

		} else if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.position += Vector3.up * speed * Time.deltaTime;

		} else if (Input.GetKey (KeyCode.DownArrow)) {
			transform.position += Vector3.down * speed * Time.deltaTime;
		}
	}

	void ShootLaser ()
	{
		if (Input.GetKey (KeyCode.Space)) {
			GameObject laser = Instantiate (projectile, transform.position, Quaternion.identity) as GameObject;

//			la
		}
	}
}
