using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Relay",menuName ="SO/relay")]
public class EventRelay :ScriptableObject
{
 [SerializeField] List<IGameEventListener> listeners;
}
