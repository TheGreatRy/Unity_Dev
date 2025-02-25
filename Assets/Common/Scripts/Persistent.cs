using UnityEngine;

public class Persistent : MonoBehaviour
{
	private void Awake()
	{
		// Ensure only one instance of this object exists
		if (GameObject.FindGameObjectsWithTag(gameObject.tag).Length > 1)
		{
			Destroy(gameObject); // Destroy duplicates
			return;
		}

		DontDestroyOnLoad(gameObject); // Make this object persistent
	}
}
