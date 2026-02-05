using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial struct EnemySystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<EnemyData>();
    }

    public void OnUpdate(ref SystemState state)
    {
        EnemyJob job = new EnemyJob
        {
            DeltaTime = SystemAPI.Time.DeltaTime,
        };

        job.ScheduleParallel();
    }
}


public partial struct EnemyJob : IJobEntity
{
    public float DeltaTime;
    
    public void Execute(ref EnemyData enemy, ref LocalTransform transform)
    {
        transform = transform.Translate(enemy.Direction * enemy.Speed * DeltaTime);
    }
}