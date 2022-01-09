using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAbility : AbilityScripts
{
    public GameObject bulletPrefab;

    public Transform shootAnchor;

    public override void Activate()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootAnchor.position, shootAnchor.rotation);
    }
}
