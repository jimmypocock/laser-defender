using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed = 15.0f;
	public GameObject projectile;
	public float projectileSpeed = 0f;
	public float firingRate = 0.2f;
	public float health = 300f;

	public AudioClip fireSound;
	public AudioClip loseSound;

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

		if (Input.GetKeyDown (KeyCode.Space)) {
			InvokeRepeating ("Fire", 0.000001f, firingRate);
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke ("Fire");
		}
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		Projectile enemyProjectile = collider.gameObject.GetComponent<Projectile> ();

		if (enemyProjectile) {
			health -= enemyProjectile.GetDamage ();
			enemyProjectile.Hit ();

			if (health <= 0) {
				AudioSource.PlayClipAtPoint (loseSound, transform.position);
				Destroy (gameObject);
			}
		}
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

	void Fire ()
	{
		GameObject laser = Instantiate (projectile, transform.position, Quaternion.identity) as GameObject;
		laser.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, projectileSpeed, 0);	

		AudioSource.PlayClipAtPoint (fireSound, transform.position);
	}
}
