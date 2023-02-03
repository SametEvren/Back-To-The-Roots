using System;

namespace polyperfect.Common.Wander_Script
{
  [Serializable]
  public class MovementState : PolyPerfect.AIState
  {
    public float maxStateTime = 40f;
    public float moveSpeed = 3f;
    public float turnSpeed = 120f;
  }
}