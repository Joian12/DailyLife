using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public class EnemyAuthoring : MonoBehaviour
{
    public float Speed;
    public float3 Direction;

    private class EnemyBaker : Baker<EnemyAuthoring>
    {
        public override void Bake(EnemyAuthoring authoring)
        {
            Entity enemy = GetEntity(TransformUsageFlags.Dynamic);
            
            AddComponent(enemy, new EnemyData
            {
                Speed = authoring.Speed,
                Direction = authoring.Direction,
            });
        }
    }
}
