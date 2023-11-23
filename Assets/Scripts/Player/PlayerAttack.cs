using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Rigidbody _rb; 
    public Transform muzzlePoint;
    public Transform weapon;
    public void Shoot()
    {
        GameObject bullet = Instantiate( Resources.Load("Prefabs/Bullet") as GameObject, muzzlePoint.position, Quaternion.Euler(90f, this.transform.rotation.y, 0f));

        _rb = bullet.GetComponent<Rigidbody>();
        //_rb.freezeRotation = true;
        //Debug.DrawLine(muzzlePoint.transform.position, shootDirection, new Color(34,142,52,1),500 );
        _rb.velocity = (weapon.transform.forward) * 80;
    }
}
