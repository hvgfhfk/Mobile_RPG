using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAction : MonoBehaviour
{
    SlimeType slimeType = new SlimeType();
    //PlayerHealth playerHealth = new PlayerHealth();
    // Item Prefabs
    [SerializeField]
    private GameObject itemPrefab;

    // Damage Text Object
    public GameObject hudDamageText;
    public Transform TextPosition;

    private void MonsterTakeDamage(int damagePower)
    {
        // Show Damage Text
        GameObject damageText = Instantiate(hudDamageText);
        damageText.transform.position = TextPosition.position;
        damageText.GetComponent<DamageText>().damage = damagePower;

        // 애니메이터

        //monsterType.hp -= damagePower;

        if(slimeType.hp <= 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        Destroy(this.gameObject);
    }

    private void MonsterItemDrop()
    {
        var diamond = Instantiate<GameObject>(this.itemPrefab);
        diamond.transform.position = this.gameObject.transform.position;
        diamond.SetActive(true);
    }

}
