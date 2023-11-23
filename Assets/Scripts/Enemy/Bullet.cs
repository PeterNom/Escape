using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Transform hitTransform = collision.transform;
        Debug.Log(hitTransform.tag);
        if (hitTransform.CompareTag("Player"))
        {
            Debug.Log("I hit the player");
            hitTransform.GetComponent<PlayerHealth>().TakeDamage(10);
        }
        else if(hitTransform.CompareTag("Enemy"))
        {
            Debug.Log("I hit an enemy.");
            hitTransform.GetComponent<Enemy>().TakeDamage(10);
        }
        Destroy(gameObject);
    }
}
