using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // 플레이어가 몬스터에게 주는 데미지 수
    public int NormalDamage = 10;
    public int SkillDamage = 30;
    public int DashDamage = 30;

    // 캐릭터의 공격 반경
    public NormalTarget normalTarget;
    public SkillTarget skillTarget;

    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void NormalAttack()
    {
        string[] attackSound = {"VoiceSample/13.attack_B1", "VoiceSample/13.attack_B1", "VoiceSample/14.attack_B2",
        "VoiceSample/15.attack_B3","VoiceSample/16.attack_C1","VoiceSample/17.attack_C2","VoiceSample/18.attack_C3"};

        PlayRandomVoice(attackSound);
        
        // normaltarget에 있는 trigger collider에 들어있는 몬스터의 리스트 조회
        List<Collider> targetList = new List<Collider>(normalTarget.targetList);

        // 타겟 리스트 안에 있는 몬스터들을 하나씩 조회
        foreach(Collider one in targetList)
        {
            EnemyHealth enemy = one.GetComponent<EnemyHealth>();
            if(enemy != null)
            {
                StartCoroutine(enemy.StartDamage(NormalDamage, transform.position, 0.5f, 0.5f));
            }
        }
    }

    public void DashAttack()
    {
        string[] attackSound = { "VoiceSample/10.attack_A1", "VoiceSample/11.attack_A2", "VoiceSample/12.attack_A3" };

        PlayRandomVoice(attackSound);
        // normaltarget에 있는 trigger collider 조회
        List<Collider> targetList = new List<Collider>(skillTarget.targetList);

        foreach (Collider one in targetList)
        {
            EnemyHealth enemy = one.GetComponent<EnemyHealth>();

            if(enemy != null)
            {
                StartCoroutine(enemy.StartDamage(DashDamage, transform.position, 1f, 2f));
            }
        }
    }

    public void SkillAttack()
    {
        List<Collider> targetList = new List<Collider>(skillTarget.targetList);

        foreach(Collider one in targetList)
        {
            EnemyHealth enemy = one.GetComponent<EnemyHealth>();

            if(enemy != null)
            {
                StartCoroutine(enemy.StartDamage(SkillDamage, transform.position, 1f, 2f));
            }
        }
    }

    void PlayRandomVoice(string[] attackSound)
    {
        int rand = UnityEngine.Random.Range(0, attackSound.Length);

        audioSource.PlayOneShot(Resources.Load(attackSound[rand]) as AudioClip);
    }
}
