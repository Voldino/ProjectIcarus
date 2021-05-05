using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissle : MonoBehaviour
{
    public static List<int> usedTargetList = null;
    private int usedIndex = -1;

    private int HP = 2; 
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
        if (usedTargetList == null)
        {
            usedTargetList = new List<int>();
        }
        target = getTarget();
        
        rb = GetComponent<Rigidbody2D>();

        same++;
    }

    private void OnDisable()
    {
        target = null; 
    }

    private void OnDestroy()
    {
        target = null;
    }
    void Start()
    {
        if (usedTargetList == null)
        {
            usedTargetList = new List<int>();
        }
        target = getTarget();
        rb = GetComponent<Rigidbody2D>();
        //print("Same is " + same);
        same++;
    }

    // Update is called once per frame
    void Update()
    {
        newTarget();
        move();
        if (target && gameObject.activeSelf) print("there is a target");
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
        Transform _target = null;
        if (GetComponent<Bullet>().sender == Bullet.SENDER.ENEMY)
        {
            GetComponent<SpriteRenderer>().color = Color.green; 
            _target = FindObjectOfType<Player>().gameObject.transform; 
            return _target; 
        }

        float shortest = Mathf.Infinity ;
        for (int i = 0; i < FindObjectOfType<SpawnerManager>().GetComponent<SpawnerManager>().activeShip.Count; i++)
        {
            if (shortest > Vector3.Distance(transform.position, FindObjectOfType<SpawnerManager>().GetComponent<SpawnerManager>().activeShip[i].transform.position)) ;
            {
                if (! used(i) || usedTargetList.Count >= FindObjectOfType<SpawnerManager>().GetComponent<SpawnerManager>().activeShip.Count)
                {
                    shortest = Vector3.Distance(transform.position, FindObjectOfType<SpawnerManager>().GetComponent<SpawnerManager>().activeShip[i].transform.position);
                    _target = FindObjectOfType<SpawnerManager>().GetComponent<SpawnerManager>().activeShip[i].transform;
                    usedIndex = i;
                }
            }
        }
        if ( _target != null && usedTargetList.Count < FindObjectOfType<SpawnerManager>().GetComponent<SpawnerManager>().activeShip.Count) usedTargetList.Add(usedIndex);
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

        if (other.GetComponent<Bullet>() && ! other.GetComponent<HomingMissle>())
        {
            if (other.GetComponent<Bullet>().sender != GetComponent<Bullet>().sender)
            {
                HP--;
                if (HP <= 0)
                {
                    other.gameObject.SetActive(false);
                    gameObject.SetActive(false);
                }
            }
             

        }

    }
}
