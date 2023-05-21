using System;

namespace LeoECSLite.UtilityAI.UtilityAI {
  public readonly struct Conclusion {
    private readonly Func<IAIAction, bool> _appliesTo;
    private readonly Func<double>          _input;
    private readonly Func<double, double>  _score;

    public readonly string Name;



    public Conclusion(
      Func<IAIAction, bool> appliesTo,
      Func<double>          input,
      Func<double, double>  score,
      string                name
    ) {
      _appliesTo = appliesTo;
      _input     = input;
      _score     = score;
      Name       = name;
    }



    public bool   AppliesTo(IAIAction action) => _appliesTo.Invoke(action);
    public double GetInput()                  => _input.Invoke();
    public double GetScore(double input)      => _score.Invoke(input);
  }
}