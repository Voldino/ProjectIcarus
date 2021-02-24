using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
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
        float scale = Random.Range(0.075f, 0.15f);
        gameObject.transform.localScale = new Vector3(scale, scale, 1);
        goTo = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        moveDirection = (goTo - (Vector2)gameObject.transform.position).normalized;
        transform.up = moveDirection;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)moveDirection.normalized * speed * Time.deltaTime;

        if (hp <= 0.0f) DestroyAsteroid();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Ship>())
        {
            collision.GetComponent<Ship>().Hit(damage);
        }
    }

    private void DestroyAsteroid(){
        SpawnerManager.activeShip.Remove(this.gameObject);

        Destroy(gameObject);
        FindObjectOfType<CameraShake>().Shake(0.25f, 1);
    }

    public void Hit(float damage)
    {
        hp -= damage; 
    }

}
