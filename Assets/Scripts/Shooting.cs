using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Shooting : MonoBehaviour
{
    /// <summary>
    /// Projectile prefab.
    /// </summary>
    public Transform bulletPrefab;

    public AudioClip firingSound;

    public float shootingRate = 0.25f;
	// Use this for initialization

    private float coolDown;


	void Start ()
	{
	    coolDown = 0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
        //When Player left clicks.
	    if (Input.GetMouseButtonDown(0))
	    {
            Vector3 mousePosition = Input.mousePosition;
	        mousePosition.z = transform.position.z - Camera.main.transform.position.z;
	        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
	        var a = Quaternion.FromToRotation(Vector3.up, mousePosition - transform.position);

            audio.PlayOneShot(firingSound);
	        Instantiate(bulletPrefab, transform.position, a);
	    }
	}
}
