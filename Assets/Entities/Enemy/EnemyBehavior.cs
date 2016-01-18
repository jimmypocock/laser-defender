using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour
{
	public GameObject projectile;
	public float projectileSpeed = 10;
	public float health = 150;
	public float shotsPerSecond = 0.5f;

	void Update ()
	{
		float probability = shotsPerSecond * Time.deltaTime;
		if (Random.value < probability) {
			Fire ();
		}
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		Projectile playerProjectile = collider.gameObject.GetComponent<Projectile> ();

		if (playerProjectile) {
			print ("enemy hit");

			health -= playerProjectile.GetDamage ();
			playerProjectile.Hit ();
			if (health <= 0) {
				Destroy (gameObject);
			}
		}
	}

	void Fire ()
	{
		Vector3 startPosition = transform.position + new Vector3 (0f, -1f, 0f);
		GameObject enemyProjectile = Instantiate (projectile, startPosition, Quaternion.identity) as GameObject;
		enemyProjectile.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -projectileSpeed);
	}
}
