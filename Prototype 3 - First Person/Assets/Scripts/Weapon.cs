using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform muzzle;

    public int curAmmo;
    public int maxAmmo;

    public bool infiniteAmmo;

    public float bulletSpeed;
    public float shootRate;
    private float lastShootTime;

    private bool isPlayer;

    void Awake()
    {
        // Disable cursor
        Cursor.lockState = CursorLockMode.Locked;

        if(GetComponent<PlayerController>())
            isPlayer = true;
    }
    
    public bool CanShoot()
    {
        if(Time.time - lastShootTime >= shootRate)
        {
            if(curAmmo > 0 || infiniteAmmo == true)
                return true;
        }

        return false;
    }

    public void Shoot()
    {
        lastShootTime = Time.time;         // Cooldown.
        curAmmo--;

        GameObject bullet = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);        // Creates an instance of the bullet prefab
                                                                                                // at muzzle's position and rotation.
        bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;     // Adds velocity to the projectile.

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
