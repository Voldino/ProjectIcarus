    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A : MonoBehaviour
{
    [SerializeField] private float damage = 5f;
    [SerializeField] private float hp = 1;
    [SerializeField] private float speed = 0.0f;

    private Vector2 goTo;
    private Vector2 moveDirection;
    private Vector2 lookDirection;
    private List<Vector2> directions;


    // Start is called before the first frame update
    void Start()
    {
        prepare();
    }

    private void prepare()
    {
        goTo = new Vector2(0,0);
        moveDirection = (goTo - (Vector2)gameObject.transform.position).normalized;
        transform.up = moveDirection;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)moveDirection.normalized * speed * Time.deltaTime;

        if (hp <= 0.0f) DestroyA();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Ship>())
        {
            collision.GetComponent<Ship>().Hit(damage);
        }
    }


    private void DestroyA()
    {
        SpawnerManager.activeShip.Remove(this.gameObject);
        Database.money += 5;
        Destroy(gameObject);
        FindObjectOfType<CameraShake>().Shake(0.25f, 1);
    }

    public void Hit(float damage)
    {
        hp -= damage;
    }
}
