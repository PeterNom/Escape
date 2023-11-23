using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Rigidbody _rb;

    public Transform muzzlePoint;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate( Resources.Load("Prefabs/Bullet") as GameObject, muzzlePoint.position, Quaternion.Euler(90f, this.transform.rotation.y, 0f));

        _rb = bullet.GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
        Vector3 pos = muzzlePoint.transform.position;
        pos.z += 10f;
        Vector3 shootDirection = (pos - muzzlePoint.transform.position).normalized;
        Debug.DrawLine(muzzlePoint.transform.position, shootDirection, new Color(34,142,52,1),500 );
        Debug.Log(shootDirection);
        _rb.velocity = shootDirection * 40;
    }
}
