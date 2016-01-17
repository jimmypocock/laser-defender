using UnityEngine;
using System.Collections;
using UnityEditor;

public class EnemySpawner : MonoBehaviour
{

	public GameObject enemyPrefab;
	public float width = 8f;
	public float height = 6f;
	public float speed = 5f;

	private bool movingRight = false;

	void Start ()
	{
		foreach (Transform child in transform) {
			// Instantiate an enemy object on Start
			GameObject enemy = Instantiate (enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;

			// Set enemy spawn to location of EnemyFormation
			enemy.transform.parent = child;
		}
	}

	void Update ()
	{
		if (movingRight) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		} else {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}

		// Change direction of formation
		float rightEdgeOfFormation = transform.position.x + (0.5f * width);
		float leftEdgeOfFormation = transform.position.x - (0.5f * width);

		if (leftEdgeOfFormation < Viewport.minX) {
			movingRight = false;

		} else if (rightEdgeOfFormation > Viewport.maxX) {
			movingRight = true;
		}
	}

	public void OnDrawGizmos ()
	{
		Gizmos.DrawWireCube (transform.position, new Vector3 (width, height));
	}
}
