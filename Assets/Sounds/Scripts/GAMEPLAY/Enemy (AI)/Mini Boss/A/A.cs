using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A : MonoBehaviour
{
    private float col_damage = 5f;
    [SerializeField] private GameObject boss;
    private float currenthealth;
    private float maxhealth;
    private BossHealthBar BHB;

    private Vector2 goTo;
    private Vector2 moveDirection;
    private Vector2 lookDirection;
    private List<Vector2> directions;

    public bool notRotate = false; 


    // Start is called before the first frame update
    void Start()
    {
        BHB = FindObjectOfType<BossHealthBar>().GetComponent<BossHealthBar>();
        maxhealth = boss.GetComponent<Ship>().getHP();
        BHB.SetMaxHealth(maxhealth);
        prepare();
    }

    private void Update()
    {
        currenthealth = boss.GetComponent<Ship>().getHP();
        BHB.SetHealth(currenthealth);
    }

    private void prepare()
    {

    }

    // Update is called once per frame


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Ship>())
        {
            collision.GetComponent<Ship>().Hit(col_damage);
        }
    }


 


}
