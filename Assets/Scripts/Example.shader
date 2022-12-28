// シェーダー名を書く、ファイル名と一致させる必要は無し
Shader "Unlit/Example"
{
    // インスペクターで設定したいプロパティを書く
    Properties
    {
        // プロパティ名 ("表示する名前", 型) = "デフォルト値" { オプション }
        // 行末に;を付けない
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1, 0, 0, 1)
    }
    // シェーダーのまとまりを記述する、複数書くことができる
    SubShader
    {
        // SubShaderブロック内に書いた場合は全てのPassブロックに適用される
        // Passブロックの中に書いたタグはそのPassブロック内にしか適用されない
        Tags { "RenderType"="Opaque" }
        
        // LevelOfDetail
        // このSubShaderを表示するのに必要なLODの値
        // 外部から設定することでこのSubShaderを表示できるかどうかが切り替わる
        LOD 100

        Pass
        {
            // ここからCg言語のプログラムを書くという合図
            CGPROGRAM

            // コンパイラに対して情報を渡すPPD
            // ここでは頂点シェーダーとフラグメントシェーダーの関数名を指定している
            #pragma vertex vert
            #pragma fragment frag
            
            // シェーダーバリアント
            // フォグ(霧)の処理が入ったシェーダーとそうでないシェーダーをコンパイル時に切り分けてくれる
            // make fog work
            #pragma multi_compile_fog

            // 別のファイルの処理を再利用する
            // 同じ処理が複数個所に書いてあったらインクルードファイルに切り分けてこんな感じで使うと良い感じ
            #include "UnityCG.cginc"

            // 頂点1つを表す構造体、名前は自由だがappdataは慣習
            struct appdata
            {
                // セマンティクス : の後ろに書かれているもの POSITION など
                // : の前に書かれている変数に対して 後ろに書いてある種類のデータを入れておくように指示する
                // = での代入に近い
                // 必要なものだけ受け取る
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            // 頂点シェーダーからフラグメントシェーダーに渡す構造体、名前は自由だがv2fは慣習
            // ラスタライズ処理で補完された値が渡される
            struct v2f
            {
                float2 uv : TEXCOORD0;
                // C++のマクロと同じ仕組みになっている、コンパイル時に文字を置き換える
                UNITY_FOG_COORDS(1)
                // 座標変換された後の頂点座標は必須
                // ピクセルシェーダーに渡される時点では自動で追加の変換が行われている
                // 画面サイズ 1920*1080 なら　x:0~1919 y:0~1079 に追加の変換がされる
                float4 vertex : SV_POSITION;
            };

            // uniform変数はグローバル変数に近い仕組み
            // シェーダーの外側(C#スクリプト)からデータを渡すことができる
            // Unity上ではUniform変数をまとめた構造体で効率化する事が多い ConstantBuffer(CBuffer)
            //uniform sampler2D _MainTex;

            // sampler2D型の変数名がPropertiesブロックのTexure2Dと同じなので値が渡される
            sampler2D _MainTex;
            // _STという変数名を付けると、Tiling(x, y)とOffest(z, w)が渡されてくる
            // 不要なら宣言しなくてもよい
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }

            // ここまでがCg言語のプログラムだという合図
            ENDCG
        }
    }
    // FallBackブロック…SubShaderブロックが実行できなかった場合に実行されるブロック
    FallBack off
}
