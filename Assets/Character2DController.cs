using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2DController : MonoBehaviour
{

    public float MovementSpeed = 1;
    Vector3 characterScale;
    float characterScaleX;

    private Animator anim;
    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        characterScale = transform.localScale;
        characterScaleX = characterScale.x;
        
    }

    // Update is called once per frame
    private void Update()
    {
        //var movement = Input.GetAxis("Horizontal");
        //  transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        transform.Translate(Input.GetAxis("Horizontal") * 15f * Time.deltaTime, 0f, 0f);

        Vector3 characterScale = transform.localScale;


        if (Input.GetAxis("Horizontal") == 0)
        {
            anim.SetBool("isWalking", false);
        }
        else
        {
            {
                anim.SetBool("isWalking", true);
            }
        }



            // Flip the Character:



            if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -characterScaleX;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = characterScaleX;
        }
        transform.localScale = characterScale;
    }

     
}
