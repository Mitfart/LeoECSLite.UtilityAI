namespace LeoECSLite.UtilityAI.AICortex {
  public struct Score {
    public double Value { get; private set; }
    
    public void Reset()           => Value =  0;
    public void Change(double by) => Value += by;
  }
}