using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// [CreateAssetMenu(fileName ="Sfx",menuName ="SO/GameEventListeners/Sfx")]]

public class SFXlistener : MonoBehaviour,IGameEventListener
{
 public UnityEvent<int> ievent;
}
