using UnityEngine;

public class Wowzers : MonoBehaviour
{
    [Range(1,10)] public float speed = 2;
    public GameObject prefab;
    private void Awake()
    {
        //print("Wakey wakey");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //print("Time for breakfast!");
    }

    // Update is called once per frame
    void Update()
    {
        // print("Egg");
        Vector3 position = transform.position;
        Vector3 velocity = Vector3.zero;
        velocity.x = Input.GetAxis("Horizontal");
        velocity.z = Input.GetAxis("Vertical");
        
        //if(Input.GetButton("Fire1"))
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    position.y += 1 * Time.deltaTime;
        //}

        transform.position += velocity * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }
}
