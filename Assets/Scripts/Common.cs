using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �U���Ɏg���f�[�^�����b�v�����N���X
/// </summary>
public class AttackData
{
    Vector3 pos;
    public float Radius { get; }
    public float Damage { get; }

    public AttackData(Vector3 pos, float radius, float damage)
    {
        this.pos = pos;
        Radius = radius;
        Damage = damage;
    }

    public bool IsHit(Vector3 target)
    {
        float distance = (target - pos).sqrMagnitude;
        return distance < Radius;
    }
}