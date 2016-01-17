using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour {

	void OnDrawGizmos () {
		// Gizmos are useful things attached to objects
		// that allows the dev to show and hide those things

		Gizmos.DrawWireSphere ( transform.position, 1 );
	}
}
