using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDamagable : MonoBehaviour,IDamagable
{
    [SerializeField]ClipTable_SO clipTable;
    [SerializeField] AudioSource audioSource;
    public void TakeDamage(int damagerIndex, int damage)
    {
        Debug.Log("Taking Damage");
        AudioClip clip= clipTable.getClip(damagerIndex);
        audioSource.PlayOneShot(clip);

    }
}
