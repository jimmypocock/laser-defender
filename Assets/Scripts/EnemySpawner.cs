using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;

	void Start () {
		// Instantiate an enemy object on Start
		GameObject enemy = Instantiate ( enemyPrefab, new Vector3 ( 0, 0, 0 ), Quaternion.identity ) as GameObject;

		// Set enemy spawn to location of EnemyFormation
		enemy.transform.parent = transform;
	}

	void Update () {
		
	}
}
