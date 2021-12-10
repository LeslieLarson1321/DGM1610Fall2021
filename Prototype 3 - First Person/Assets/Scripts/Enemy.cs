using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class Enemy : MonoBehaviour
{
    public int curHp, maxHp, scoreToGive;                   // Enemy Stats

    public float moveSpeed, attackRange, yPathOffset;       // Movement

    private List<Vector3> path;               // Path Coordinates

    private Weapon weapon;          // Enemy's Weapon

    private GameObject target;             // Target to Follow

    
    // Start is called before the first frame update
    void Start()
    {
        // Gets the Components
        weapon = GetComponent<Weapon>();
        target = FindObjectOfType<PlayerController>().gameObject;
        InvokeRepeating("UpdatePath", 0.0f, 0.5f);

        curHp = maxHp;
    }

    void UpdatePath()
    {
        // Calculates a path to the target.
        NavMeshPath navMeshPath = new NavMeshPath();
        NavMesh.CalculatePath(transform.position, target.transform.position, NavMesh.AllAreas, navMeshPath);

        path = navMeshPath.corners.ToList();
    }
   
    void ChaseTarget()
    {
        if(path.Count == 0)
            return;
    
        // Move towards the closest path
        transform.position = Vector3.MoveTowards(transform.position, path[0] + new Vector3(0,yPathOffset,0), moveSpeed * Time.deltaTime);

        if(transform.position == path[0] + new Vector3(0, yPathOffset, 0))
            path.RemoveAt(0);
    }
        // Applies damage to the player.
    public void TakeDamage(int damage)
    {
        curHp -= damage;

        if(curHp <= 0)
            Die();
    }
        // If player's health is reduced to zero or below, then run "Die."
    void Die()
    { 
        Destroy(gameObject);
    }

    void Update()
    {
        // Look at the target
        Vector3 dir = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.x,dir.z) * Mathf.Rad2Deg;
        transform.eulerAngles = Vector3.up * angle;
    
        // Calculates the distance between the enemy and the player.
        float dist = Vector3.Distance(transform.position, target.transform.position);

            // If within attack range, it'll attack the player.
        if(dist <= attackRange)
        {
            if(weapon.CanShoot())
                weapon.Shoot();
        }

            // If the enemy is too far away, it'll chase after the player.
        else
        {
            ChaseTarget();
        }

    }

}
