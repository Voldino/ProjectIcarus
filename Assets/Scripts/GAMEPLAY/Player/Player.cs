using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class Player : MonoBehaviour
{
    [HideInInspector]
    public delegate void PowerUpDelegate();
    public PowerUpDelegate PowerUp = null;

    [SerializeField] 
    private float countTime= 0;
    private float delayTime = 1000.0f;

    private void Start()
    {
        loadFromDatabase();
    }

    private void loadFromDatabase()
    {
        Ship ship = GetComponent<Ship>(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        OutOfBount();

        if (PowerUp != null)
        {

            countTime += 1 * Time.deltaTime;
            PowerUp();


            if (countTime < delayTime)
            {
                PowerUp = null;
                countTime = 0;
            }
        }
    }

    public void GameOver()
    {

        SceneManager.LoadScene(0);

    }

    public void IncreaseAttack()
    {
        Ship ship = gameObject.GetComponent<Ship>();
        ship.setDamage(ship.getDamage()+100);
    }


    private void OutOfBount()
    {
        float yBound = 5.35f, xBound = 9.10f;
        if (transform.position.y > yBound) transform.position = new Vector2(transform.position.x, -transform.position.y + 0.1f);
        else if (transform.position.y < -yBound) transform.position = new Vector2(transform.position.x, -transform.position.y - 0.1f);

        if (transform.position.x > xBound) transform.position = new Vector2(-transform.position.x + 0.1f, transform.position.y);
        else if (transform.position.x < -xBound) transform.position = new Vector2(-transform.position.x - 0.1f, transform.position.y);
    }

    public void Hit(float damage)
    {
        gameObject.GetComponent<Ship>().Hit(damage);
    }


}
