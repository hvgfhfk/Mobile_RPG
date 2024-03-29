using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // 캐릭터의 공격 반경
    public NormalTarget normalTarget;
    public SkillTarget skillTarget;

    public AudioSource audioSource;

    [SerializeField]
    private UI uiCurrent;

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
                StartCoroutine(enemy.StartDamage(uiCurrent.normalCalc, transform.position, 0.5f, 0.5f));
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
                StartCoroutine(enemy.StartDamage(uiCurrent.dashCalc, transform.position, 0.1f, 0.1f));
            }
        }
    }

    void PlayRandomVoice(string[] attackSound)
    {
        int rand = UnityEngine.Random.Range(0, attackSound.Length);

        audioSource.PlayOneShot(Resources.Load(attackSound[rand]) as AudioClip);
    }
}
