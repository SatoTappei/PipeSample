using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// アイテムのデータのクラス
/// </summary>
public readonly struct ItemData : IEquatable<ItemData>
{
    public int Score { get; }

    public ItemData(int score)
    {
        Score = score;
    }

    public bool Equals(ItemData other)
    {
        throw new NotImplementedException();
    }
}
