using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum effectPower {ATTACK,HEALER };
    public effectPower effect = effectPower.ATTACK;

    private void PickUp(Player player)
    {
        if (effect == effectPower.ATTACK)
        { 
            player.PowerUp = player.IncreaseAttack;
        }
        else if (effect == effectPower.HEALER)
        {
            player.PowerUp = player.Healer; 
        }
        Destroy(gameObject); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>())
        {
            PickUp(other.GetComponent<Player>());
        }


    }

}
