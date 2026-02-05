using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public struct EnemyData : IComponentData
{
    public float Speed;
    public float3 Direction;
}
