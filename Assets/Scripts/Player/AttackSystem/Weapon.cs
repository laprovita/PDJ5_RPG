using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] BoxCollider colliderWeapon;
    [SerializeField] int damageForAnimation;

    public void ActiveAttack(int damage, float timeOnCollider)
    {
        colliderWeapon.enabled = true;
        damageForAnimation = damage;
        StartCoroutine(CooldownAttack(timeOnCollider));
    }

    private void DesactiveAttack()
    {
        colliderWeapon.enabled = false;
        damageForAnimation = 0;
    }

    IEnumerator CooldownAttack(float timeCd)
    {
        yield return new WaitForSeconds(timeCd);
        DesactiveAttack();
    }

    private void Update()
    {
    }

    public string ReturnAttack()
    {
        return "Attack";
    }
}
