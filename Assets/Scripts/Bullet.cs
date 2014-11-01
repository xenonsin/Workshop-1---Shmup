using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Bullet : MonoBehaviour
{

    public float shootDistance;
    public float shootSpeed;
    public float damage;

    void OnEnable()
    {
        StartCoroutine(Shoot());
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator Shoot()
    {
        float travelledDistance = 0;
        while (travelledDistance < shootDistance)
        {
            travelledDistance += shootSpeed * Time.deltaTime;
            transform.position += transform.up * (shootSpeed * Time.deltaTime);
            yield return 0;
        }
        Destroy(gameObject);
    }
}
