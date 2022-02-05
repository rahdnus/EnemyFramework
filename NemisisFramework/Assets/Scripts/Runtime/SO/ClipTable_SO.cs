using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ClipTable",menuName ="SO/ClipTable")]
public class ClipTable_SO : ScriptableObject
{
    public ClipTable[] audioClips;

    public AudioClip getClip(int index)
    {
        foreach(ClipTable clip in audioClips)
        {
            if(index==clip.clipIndex)
            {
                int randomindex=Random.Range(0,clip.audioClip.GetLength(0));
                return clip.audioClip[randomindex];
            }
        }
        return null;
    }
}
[System.Serializable]
public class ClipTable
{
    public int clipIndex;
    public AudioClip[] audioClip;
}
