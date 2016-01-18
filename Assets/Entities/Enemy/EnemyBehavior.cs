using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour
{

	public float health = 150;

	void OnTriggerEnter2D (Collider2D collider)
	{
		Projectile projectile = collider.gameObject.GetComponent<Projectile> ();

		if (projectile) {
			health -= projectile.GetDamage ();
			projectile.Hit ();
			if (health <= 0) {
				Destroy (gameObject);
			}
		}
	}
}
