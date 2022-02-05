using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_Particle_Manager : MonoBehaviour
{
    [SerializeField] SFXnParticles[] snps;
    Dictionary<LayerMask,SFXnParticles> mydictionary=new Dictionary<LayerMask, SFXnParticles>();

    public AudioSource audioSource;

    void Start()
    {
        foreach(SFXnParticles snp in snps)
        {
            mydictionary.Add(snp.layerMask,snp);
        }

    }

    public void Play(int layer,Vector3 pos,Quaternion rotation)
    {
        SFXnParticles snp;
        int layerinbits=1;
        while(layer!=0)
        {
            layerinbits=layerinbits<<1;
            layer--;
        }
        mydictionary.TryGetValue(layerinbits,out snp);
        audioSource.gameObject.transform.position=pos;
        int length=snp.sfxs.Length;
        int i=Random.Range(0,length);
        audioSource.PlayOneShot(snp.sfxs[i]);

        GameObject particle=Instantiate(snp.particle,pos,rotation).gameObject as GameObject;
        Destroy(particle,3);

    }
    public void Play(AudioSource source,SFXnParticles snp,Vector3 pos)
    {
        int length=snp.sfxs.Length;
        int i=Random.Range(0,length);
        source.PlayOneShot(snp.sfxs[i]);
        GameObject particle=Instantiate(snp.particle,pos,Quaternion.identity).gameObject as GameObject;
        Destroy(particle,3);
    }
}
[System.Serializable]
public class SFXnParticles
{
    public LayerMask layerMask;
    public AudioClip[] sfxs;
    public ParticleSystem particle;
}
