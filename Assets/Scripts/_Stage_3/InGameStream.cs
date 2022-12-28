using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stage3
{
    /// <summary>
    /// ゲーム全体の流れを制御するコンポーネント
    /// </summary>
    public class InGameStream : MonoBehaviour
    {
        // 敵のステートマシン
        // 待機中 <=> うろうろ 
        // 発見すると近づいてくる
        // 足元に床が無いとジャンプする
        // プレイヤーに近づいたら攻撃(殴る)してくる

        // サービスロケータ
        // 音を鳴らす処理
        // ログを出す処理 <= いちいちサービスロケータから取得していたら手間がかかりすぎるので×

        // 型オブジェクト
        // 敵は同じ系統の敵が3種類いて1種類は例外持ち
        // 敵の攻撃の際のParticleが違う

        // インターフェース
        // プレイヤーと敵のあらゆる行動をインターフェースで実装する

        // ポーズ
        // メニューを開いている間
        // プレイヤー,敵,残り時間 を止める

        void Start()
        {

        }

        void Update()
        {

        }
    }
}
