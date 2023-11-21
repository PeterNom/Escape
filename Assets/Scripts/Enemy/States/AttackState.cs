using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackState : BaseState
{
    private float moveTimer;
    private float losePlayerTimer;
    private float shotTimer;
    private Rigidbody _rb;
    public override void Enter()
    {
        
    }

    public override void Exit()
    {
       
    }

    public override void Perform()
    {
        if (enemy.CanSeePlayer())
        {
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            shotTimer += Time.deltaTime;
            enemy.transform.LookAt(enemy.Player.transform);

            if(shotTimer>enemy.fireRate)
            {
                Shoot();
            }
            if(moveTimer> Random.Range(3,7))
            {
                enemy.Agent.SetDestination(enemy.transform.position+ (Random.insideUnitSphere * 5));
                moveTimer = 0;
            }
            enemy.LastKnownPos = enemy.Player.transform.position;
        }
        else
        {
            losePlayerTimer += Time.deltaTime;
            if(losePlayerTimer>8)
            {
                //change to the search state.
                stateMachine.ChangeState(new SearchState());
            }
        }
    }

    public void Shoot()
    {
        Debug.Log("Shoot");
        Transform gunbarrel = enemy.gunBarrel;
        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Bullet") as GameObject, gunbarrel.position, enemy.transform.rotation);
        _rb = bullet.GetComponent<Rigidbody>();
        _rb.rotation = Quaternion.Euler(90f, 0f, 0f);
        _rb.freezeRotation = true;
        Vector3 shootDirection = (enemy.Player.transform.position - gunbarrel.transform.position).normalized;
        bullet.GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(Random.Range(-3f,3f),Vector3.up) * shootDirection * 80;

        shotTimer = 0;

    }
}
