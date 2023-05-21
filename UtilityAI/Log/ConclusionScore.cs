namespace LeoECSLite.UtilityAI.UtilityAI.Log {
  public readonly struct ConclusionScore {
    public string Name  { get; }
    public double Score { get; }

    public ConclusionScore(string name, double score) {
      Name  = name;
      Score = score;
    }

    public override string ToString() => $"{Name} -> \t\t\t {(Score >= 0 ? "+" : " ")}{Score}";
  }
}