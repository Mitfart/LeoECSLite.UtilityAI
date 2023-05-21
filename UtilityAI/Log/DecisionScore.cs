namespace LeoECSLite.UtilityAI.UtilityAI.Log {
  public readonly struct DecisionScore {
    public IAIAction IaiAction { get; }
    public double    Score     { get; }

    public DecisionScore(IAIAction iaiAction, double score) {
      IaiAction = iaiAction;
      Score     = score;
    }

    public override string ToString() => $"{IaiAction} \t\t\t | Score: {Score}";
  }
}