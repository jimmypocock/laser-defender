using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour
{
	public GameObject projectile;
	public float projectileSpeed = 10;
	public float health = 150;
	public float shotsPerSecond = 0.5f;
	public int scoreValue = 121;
	public AudioClip fireSound;
	public AudioClip deathSound;

	private ScoreKeeper scoreKeeper;

	void Start ()
	{
		scoreKeeper = GameObject.Find ("ScoreNumber").GetComponent<ScoreKeeper> ();
	}

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
			health -= playerProjectile.GetDamage ();
			playerProjectile.Hit ();

			if (health <= 0) {
				Die ();
			}
		}
	}

	void Fire ()
	{
		GameObject enemyProjectile = Instantiate (projectile, transform.position, Quaternion.identity) as GameObject;
		enemyProjectile.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -projectileSpeed);

		AudioSource.PlayClipAtPoint (fireSound, transform.position);
	}

	void Die ()
	{
		scoreKeeper.Score (scoreValue);
		Destroy (gameObject);
		AudioSource.PlayClipAtPoint (deathSound, transform.position);
	}
}
