using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Turrent : MonoBehaviour
{
    [SerializeField] Transform barrel;
    [SerializeField] GameObject player;
    [SerializeField] GameObject rocket;
    [SerializeField] int maxForce;
    [SerializeField, Range(0.5f, 5)] float spawnTime;

    Rigidbody rb;
    
    float spawnTimer;
     void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        if (player.tag == "Player")
        {
            transform.LookAt(player.transform.position);
        }
        
    }
    private void FixedUpdate()
    {
        if (tag == "PurpleEnemy")
        {
            rb.AddRelativeForce(Vector3.forward * maxForce);
        }
    }
}
