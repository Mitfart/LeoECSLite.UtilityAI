using System;
using System.Collections.Generic;

namespace LeoECSLite.UtilityAI.AICortex.Extentions.IEnumerable {
  public static class FindMaxExt {
    public static T FindMax<T>(this IEnumerable<T> enumerable, Func<T, double> getValue) {
      double maxValue  = double.MinValue;
      T      maxObject = default;

      foreach (T obj in enumerable) {
        double curValue = getValue.Invoke(maxObject);

        if (curValue <= maxValue)
          continue;

        maxValue  = curValue;
        maxObject = obj;
      }

      return maxObject;
    }
  }
}