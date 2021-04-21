using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [HideInInspector]
    public delegate void PowerUpDelegate();
    public PowerUpDelegate PowerUp = null;

 
    [SerializeField] 
    private float countTime= 0;
    private float delayTime = 1000.0f;

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    private void Start()
    {
        loadFromDatabase();
        SoundManager.Instance.Stop("CantinaTune");
        SoundManager.Instance.Play("NormalStages") ; 
        SetMaxHealth(GetComponent<Ship>().getHP());
    }

    private void loadFromDatabase()
    {
        Ship ship = GetComponent<Ship>();
    }

    // Update is called once per frame
    void Update()
    {
        OutOfBount();
        slider.value = GetComponent<Ship>().getHP() ;
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
        TransitionManager.instance.Sc_Cantina();

    }

    public void IncreaseAttack()
    {
        Ship ship = gameObject.GetComponent<Ship>();
        ship.setDamage(ship.getDamage()+1);
    }

    public void Healer()
    {
        Ship ship = gameObject.GetComponent<Ship>();
        ship.setHP(slider.maxValue * 2);
        SetMaxHealth(ship.getHP());
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

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;

        //fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
        slider.value = health;

        //fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    

}
