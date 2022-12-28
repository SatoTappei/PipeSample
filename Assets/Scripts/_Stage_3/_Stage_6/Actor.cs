//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using State = StateMachine<Actor>.State;

///// <summary>
///// 汎用型ステートマシンを利用する側のコンポーネント
///// </summary>
//public class Actor : MonoBehaviour
//{
//    /// <summary>状態を表す列挙型</summary>
//    enum Event : int
//    {
//        Timeout,
//        FindEnemy,
//        DefeatEnemy,
//        DefeatAllEnemy,
//    }

//    /// <summary>その場で回転するクラス</summary>
//    class StateRotation : State
//    {

//    }

//    /// <summary>前進するクラス</summary>
//    class StateMoveForward : State
//    {
//        // 時間切れにより時間切れステートに移行する処理
//    }

//    /// <summary>終了</summary>
//    class StateEnd : State
//    {
//        // スクリプトを非アクティブにする
//    }

//    /// <summary>Actor型のステートマシン</summary>
//    StateMachine<Actor> _stateMachine;

//    void Start()
//    {
//        // 現在のステートと遷移先のステートとIDとして使うイベントの列挙型を登録する
//        _stateMachine = new StateMachine<Actor>(this);
//        _stateMachine.AddTransition<StateRotation, StateMoveForward>((int)Event.FindEnemy);
//        _stateMachine.AddTransition<StateMoveForward, StateRotation>((int)Event.DefeatEnemy);
//        _stateMachine.AddTransition<StateMoveForward, StateRotation>((int)Event.Timeout);

//        // どのステートからでも遷移できるステートを登録する
//        _stateMachine.AddAnyTransition<StateEnd>((int)Event.DefeatAllEnemy);

//        // ステートマシンの起点を設定する
//        _stateMachine.Start<StateRotation>();
//    }

//    //void Update()
//    //{
//    //    // TODO:敵が全滅していたらreturnする

//    //    _stateMachine.Update();

//    //    // 各ステートクラスに遷移条件を書かず、ステートマシンを呼び出す側に書く
//    //    if (Input.GetKeyDown(KeyCode.C)/* 実際の遷移条件の仕組みを書く */)
//    //    {
//    //        _stateMachine.Dispatch((int)Event.FindEnemy);
//    //    }
//    //}
//}
