using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWeapon : MonoBehaviour
{
    public int damageAmount = 20;
    // Start is called before the first frame update
//    private void Start()
//    {
//        Destroy(gameObject, 10);
//    }

    // Update is called once per frame
//    private void OnTriggerEnter(Collider other)
//    {
//        Destroy(transform.GetComponent<Rigidbody>());
//        if(other.tag == "Enemy")
//        {
//            other.GetComponent<Enemy>().TakeDamage(damageAmount);
//        }
//        
//   }
     private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damageAmount);
        }
    }
}
