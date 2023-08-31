using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeManager : MonoBehaviour
{
    public int health;
    public int attack;
    public GameObject character;

    private void Start()
    {
        character.SetActive(true);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
    }

    public void DealDamage(GameObject target)
    {
        var atm = target.GetComponent<AttributeManager>();
        if(atm != null)
        {
            atm.TakeDamage(attack);
        }
    }

    private void Update()
    {
        if(health <= 0)
        {
            character.SetActive(false);
        }
    }
}
