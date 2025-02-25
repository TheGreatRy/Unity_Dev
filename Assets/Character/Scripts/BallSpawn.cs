using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    [SerializeField] private PoolSO pool;
    
    void Start()
    { }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space ) )
        {
            GameObject ball = pool.Get();
            ball.transform.position = transform.position;
            ball.SetActive( true );
        }
    }
}
