using UnityEditor;
using UnityEngine;

public class Turrent : MonoBehaviour
{
    [SerializeField] Transform barrel;
    [SerializeField] GameObject rocket;
    [SerializeField, Range(0.5f, 5)] float spawnTime;

    float spawnTimer;
     void Start()
    {
        spawnTimer = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= spawnTimer)
        {
            spawnTimer = Time.time + spawnTime;
            Instantiate(rocket, barrel.position, barrel.rotation);
        }
    }
}
