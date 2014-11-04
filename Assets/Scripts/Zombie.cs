using System.Reflection;
using UnityEngine;
using System.Collections;

public class Zombie : Entity
{
    public delegate void ZombieDeath();
    public static event ZombieDeath Dead;


    public string name;
    public float maxhp;
    public float damage;
    public float speed;
	// Use this for initialization

    public GameObject target;

    void OnEnable()
    {
        Player.Dead += Death;
    }

    void OnDisable()
    {
        Player.Dead -= Death;
    }

    public override void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        Name = name;
        MaxHealth = maxhp;

        base.Awake();

    }

    public override void Death()
    {
        if (Dead != null)
            Dead();

        base.Death();
    }

    public void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Bullet bullet = otherCollider.gameObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            Hit(bullet.damage);
            Destroy(bullet.gameObject);
        }
    }

    public override void Update()
    {
        Vector2 velocity = new Vector2((transform.position.x -target.transform.position.x), (transform.position.y - target.transform.position.y));
        rigidbody2D.velocity = -velocity * speed;

        Vector3 dir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg -90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        base.Update();
    }
}
