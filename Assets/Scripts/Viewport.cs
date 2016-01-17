using UnityEngine;
using System.Collections;

public class Viewport : MonoBehaviour
{
	public float padding = 0.5f;

	public static float minX;
	public static float maxX;
	public static float minY;
	public static float maxY;

	// Use this for initialization
	void Start ()
	{
		FindViewportEdges ();
	}

	void FindViewportEdges ()
	{

		// Distance between camera and object in 3D world.
		float distance = transform.position.z - Camera.main.transform.position.z;

		Vector3 leftMost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance));

		minX = leftMost.x + padding;
		maxX = rightMost.x - padding;

		Vector3 bottomMost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));
		Vector3 topMost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, distance));

		minY = bottomMost.y + padding;
		maxY = topMost.y - padding;
	}
}
