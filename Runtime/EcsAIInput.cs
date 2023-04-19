using System;
using System.Collections.Generic;
using Leopotam.EcsLite;

namespace LeoECSLite.UtilityAI.Runtime {
  public static class EcsAIInput {
    private const double TRUE  = 1;
    private const double FALSE = 0;

    private static readonly Dictionary<EcsWorld, Dictionary<Type, IEcsPool>> _WorldsPoolsCache = new();
    
    private static int      _Entity;
    private static EcsWorld _World;


    
    internal static void Set(int e, EcsWorld world) {
      _Entity = e;
      _World  = world;
      
      if (!HasPoolsCacheFor(world))
        InitPoolsCacheFor(world);
    }



    public static double Has<T>() where T : struct {
      return GetPool<T>().Has(_Entity) ? TRUE : FALSE;
    }

    public static double TryGet<T>(out T component) where T : struct {
      IEcsPool pool = GetPool<T>();

      if (pool.Has(_Entity)) {
        component = (T) pool.GetRaw(_Entity);
        return TRUE;
      }

      component = default;
      return FALSE;
    }

    public static T Get<T>() where T : struct {
      return (T)
        GetPool<T>()
         .GetRaw(_Entity);
    }



    private static bool HasPoolsCacheFor(EcsWorld world) {
      return _WorldsPoolsCache.TryGetValue(world, out Dictionary<Type, IEcsPool> pools)
          && pools != null;
    }

    private static void InitPoolsCacheFor(EcsWorld world) {
      _WorldsPoolsCache[world] = new Dictionary<Type, IEcsPool>(16);
    }


    private static IEcsPool GetPool<T>() where T : struct {
      return _WorldsPoolsCache[_World].TryGetValue(typeof(T), out IEcsPool pool)
        ? pool
        : CachePool<T>();
    }

    private static IEcsPool CachePool<T>() where T : struct {
      return _WorldsPoolsCache[_World][typeof(T)] = _World.GetPool<T>();
    }
  }
}