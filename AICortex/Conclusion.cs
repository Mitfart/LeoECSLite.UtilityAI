using System;

namespace LeoECSLite.UtilityAI.AICortex {
  public struct Conclusion {
    public readonly Func<IDecision, bool> When;
    public readonly double                Value;
    public readonly string                Title;

    public Conclusion(
      Func<IDecision, bool> when,
      double                value,
      string                title
    ) {
      When  = when;
      Value = value;
      Title = title;
    }
  }
}