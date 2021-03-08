using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissle : MonoBehaviour
{
    public static List<int> usedTargetList = null;
    private int usedIndex = -1;

    public float speed = 5;
    public float rotatingSpeed = 200;
    public Transform target;
    public float angleChangingSpeed = 10f;
    public float movementSpeed = 10f;
    static int same = 0;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void OnEnable()
    {
        if (usedTargetList == null) usedTargetList = new List<int>();
        target = getTarget();
        rb = GetComponent<Rigidbody2D>();
        print("Same is " +same);
        same++;
    }

    void Start()
    {
        OnEnable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        newTarget();
        move();
        //print(usedTargetList.Count);
    }

    private void newTarget()
    {
        if (target == null)
        {
            print("B");
            target = getTarget();
            usedTargetList.Remove(usedIndex);
        }
    }

    private void move()
    {
        Vector2 direction = new Vector2()  ;
        float rotateAmount = 0  ;
        if (target != null)
        {
            direction = (target.position - transform.position).normalized;
            rotateAmount = Vector3.Cross(direction, transform.up).z;
        }

        rb.angularVelocity = -rotatingSpeed * rotateAmount;
        rb.velocity = gameObject.transform.up * speed;
    }

    private Transform getTarget()
    {
        float shortest = Mathf.Infinity ;
        Transform _target = null ; 
        for (int i = 0; i < SpawnerManager.activeShip.Count; i++)
        {
            if (shortest > Vector3.Distance(transform.position, SpawnerManager.activeShip[i].transform.position)) ;
            {
                if (! used(i) || usedTargetList.Count >= SpawnerManager.activeShip.Count)
                {
                    shortest = Vector3.Distance(transform.position, SpawnerManager.activeShip[i].transform.position);
                    _target = SpawnerManager.activeShip[i].transform;
                    usedIndex = i;
                }
            }
        }
        if ( _target != null) usedTargetList.Add(usedIndex);
        return _target ;
    }

    private bool used(int index)
    {
        if (usedTargetList.Count > 0)
        {
            if (usedTargetList.Contains(index)) return true;
        }
        return false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GetComponent<Bullet>().sender == Bullet.SENDER.ENEMY)
        {
            if (other.GetComponent<Player>()  )
            {
                usedTargetList.Remove(usedIndex);
            }
        }

        if (GetComponent<Bullet>().sender == Bullet.SENDER.PLAYER)
        {
            if (other.CompareTag("Enemy"))
            {
                usedTargetList.Remove(usedIndex);
            }
        }

    }
}
