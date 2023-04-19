using System;

namespace LeoECSLite.UtilityAI.AICortex.CortexUtils {
  public static class Score {
    public static double AsIs(double input) 
      => input;

    public static Func<double, double> IfWhen(double onTrue, double onFalse = 0) 
      => input => input > 0 ? onTrue : onFalse;
  }
}