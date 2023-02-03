using System;
using UnityEngine;

namespace polyperfect.Common.Wander_Script
{
  [Serializable]
  public class IdleState : PolyPerfect.AIState
  {
    public float minStateTime = 20f;
    public float maxStateTime = 40f;
    [Tooltip("Chance of it choosing this state, in comparion to other state weights.")]
    public int stateWeight = 20;
  }
}