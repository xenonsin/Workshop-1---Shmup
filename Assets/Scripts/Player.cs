using UnityEngine;
using System.Collections;

public class Player : Entity
{
    public string name;
    public float maxhp;

    private float damageDelay = 1f;
    private bool readyToGetDamaged = true;

	// Use this for initialization
	public override void Awake()
	{
	    Name = name;
	    MaxHealth = maxhp;

        base.Awake();

	}

    public void OnCollisionStay2D(Collision2D otherCollider)
    {
        Zombie zombie = otherCollider.gameObject.GetComponent<Zombie>();
        if (zombie != null && readyToGetDamaged)
        {
            
            Hit(zombie.damage);
            readyToGetDamaged = false;
            Invoke("ResetReadyToGetDamaged", damageDelay);

        }

        //base.OnTriggerEnter2D(otherCollider);
    }

    void ResetReadyToGetDamaged()
    {
        readyToGetDamaged = true;
    }
}
