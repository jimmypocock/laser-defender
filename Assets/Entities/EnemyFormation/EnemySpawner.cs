using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

	public GameObject enemyPrefab;
	public float width = 8f;
	public float height = 6f;
	public float speed = 5f;
	public float spawnDelay = 0.5f;

	private bool movingRight = false;

	void Start ()
	{
		SpawnUntilFull ();
	}

	void SpawnEnemies ()
	{
		foreach (Transform child in transform) {
			// Instantiate an enemy object on Start
			GameObject enemy = Instantiate (enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;

			// Set enemy spawn to location of EnemyFormation
			enemy.transform.parent = child;
		}
	}

	void SpawnUntilFull ()
	{
		Transform freePosition = NextFreePosition ();
		if (freePosition) {
			GameObject enemy = Instantiate (enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePosition;
		}
		if (NextFreePosition ()) {
			Invoke ("SpawnUntilFull", spawnDelay);
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

		if (AllMembersDead ()) {
			SpawnUntilFull ();
		}
	}

	Transform NextFreePosition ()
	{
		foreach (Transform childPositionGameObject in transform) {
			if (childPositionGameObject.childCount == 0) {
				return childPositionGameObject;
			}
		}
		return null;
	}

	bool AllMembersDead ()
	{
		foreach (Transform childPositionGameObject in transform) {
			if (childPositionGameObject.childCount > 0) {
				return false;
			}
		}
		return true;
	}

	public void OnDrawGizmos ()
	{
		Gizmos.DrawWireCube (transform.position, new Vector3 (width, height));
	}
}
