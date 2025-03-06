using UnityEngine;

public class Destruct : MonoBehaviour
{
    [SerializeField] float lifetime = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

}
