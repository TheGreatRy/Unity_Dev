using UnityEngine;

public class Instaniate : MonoBehaviour
{
	[SerializeField] GameObject prefab;
	[SerializeField] Transform parent;
	[SerializeField] bool instantiateOnStart = true;

	void Start()
	{
		if (instantiateOnStart)	Instantiate();
	}

	public void Instantiate()
	{
		GameObject gameObject = (parent != null) ? Instantiate(prefab, parent) : Instantiate(prefab, transform.position, transform.rotation);
	}
}
