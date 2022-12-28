using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stage3
{
    /// <summary>
    /// ジェネリックなステートマシン
    /// </summary>
    public class StateMachineBase<TUser>
    {
        public StateMachineBase()
        {

        }
    }

    /// <summary>
    /// 各ステートの抽象クラス
    /// </summary>
    public abstract class State
    {

    }
}
