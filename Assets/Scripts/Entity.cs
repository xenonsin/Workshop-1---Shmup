using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public abstract class Entity : MonoBehaviour
{
    public string Name { get; set; }
    public float Health { get; set; }
    public float MaxHealth { get; set; }

    public virtual void Hit(float damage)
    {
        Health -= damage;
        Debug.Log(Name + " Health: " + Health.ToString());
    }

    public virtual void Heal(float heal)
    {
        Health += heal;
        Debug.Log(Name + " Health: " + Health.ToString());
    }

    public virtual void Death()
    {
        Destroy(gameObject);
    }

    public virtual void Awake()
    {
        Health = MaxHealth;
    }

    public virtual void Update()
    {
        if (Health <= 0)
            Death();
    }



}
	
