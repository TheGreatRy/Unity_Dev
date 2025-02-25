using System.Collections;
using UnityEngine;

public class PoolBall : MonoBehaviour, IPoolable<GameObject>
{
    public IPool<GameObject> Pool { get; set; }
    public void OnSpawn()
    {
        Debug.Log("Ball Located");
        StartCoroutine(WaitToRelease(2f));

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(Random.insideUnitSphere * 10, ForceMode.VelocityChange);
    }

    public void OnDespawn()
    {
        Debug.Log("Ball Lost");
    }


    IEnumerator WaitToRelease(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Pool.Release(gameObject);
    }
}
