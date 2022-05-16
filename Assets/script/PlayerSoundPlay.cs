using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundPlay : MonoBehaviour
{
    public void PlayStepSound(AudioClip step)
    {
        Manager.instance.manager_SE.audio.PlayOneShot(step);
    }
    public void PlayAttackSound(AudioClip Attack)
    {
        Manager.instance.manager_SE.audio.PlayOneShot(Attack);
    }
}
