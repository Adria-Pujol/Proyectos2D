using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public Transform firePoint;

    // Update is called once per frame
    public void Shoot()
    {
        BulletPooler.Instance.SpawnFromPool("Bullet", firePoint.position, Quaternion.identity); 
    }
}
