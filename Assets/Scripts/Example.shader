// �V�F�[�_�[���������A�t�@�C�����ƈ�v������K�v�͖���
Shader "Unlit/Example"
{
    // �C���X�y�N�^�[�Őݒ肵�����v���p�e�B������
    Properties
    {
        // �v���p�e�B�� ("�\�����閼�O", �^) = "�f�t�H���g�l" { �I�v�V���� }
        // �s����;��t���Ȃ�
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1, 0, 0, 1)
    }
    // �V�F�[�_�[�̂܂Ƃ܂���L�q����A�����������Ƃ��ł���
    SubShader
    {
        // SubShader�u���b�N���ɏ������ꍇ�͑S�Ă�Pass�u���b�N�ɓK�p�����
        // Pass�u���b�N�̒��ɏ������^�O�͂���Pass�u���b�N���ɂ����K�p����Ȃ�
        Tags { "RenderType"="Opaque" }
        
        // LevelOfDetail
        // ����SubShader��\������̂ɕK�v��LOD�̒l
        // �O������ݒ肷�邱�Ƃł���SubShader��\���ł��邩�ǂ������؂�ւ��
        LOD 100

        Pass
        {
            // ��������Cg����̃v���O�����������Ƃ������}
            CGPROGRAM

            // �R���p�C���ɑ΂��ď���n��PPD
            // �����ł͒��_�V�F�[�_�[�ƃt���O�����g�V�F�[�_�[�̊֐������w�肵�Ă���
            #pragma vertex vert
            #pragma fragment frag
            
            // �V�F�[�_�[�o���A���g
            // �t�H�O(��)�̏������������V�F�[�_�[�Ƃ����łȂ��V�F�[�_�[���R���p�C�����ɐ؂蕪���Ă����
            // make fog work
            #pragma multi_compile_fog

            // �ʂ̃t�@�C���̏������ė��p����
            // �����������������ɏ����Ă�������C���N���[�h�t�@�C���ɐ؂蕪���Ă���Ȋ����Ŏg���Ɨǂ�����
            #include "UnityCG.cginc"

            // ���_1��\���\���́A���O�͎��R����appdata�͊��K
            struct appdata
            {
                // �Z�}���e�B�N�X : �̌��ɏ�����Ă������ POSITION �Ȃ�
                // : �̑O�ɏ�����Ă���ϐ��ɑ΂��� ���ɏ����Ă����ނ̃f�[�^�����Ă����悤�Ɏw������
                // = �ł̑���ɋ߂�
                // �K�v�Ȃ��̂����󂯎��
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            // ���_�V�F�[�_�[����t���O�����g�V�F�[�_�[�ɓn���\���́A���O�͎��R����v2f�͊��K
            // ���X�^���C�Y�����ŕ⊮���ꂽ�l���n�����
            struct v2f
            {
                float2 uv : TEXCOORD0;
                // C++�̃}�N���Ɠ����d�g�݂ɂȂ��Ă���A�R���p�C�����ɕ�����u��������
                UNITY_FOG_COORDS(1)
                // ���W�ϊ����ꂽ��̒��_���W�͕K�{
                // �s�N�Z���V�F�[�_�[�ɓn����鎞�_�ł͎����Œǉ��̕ϊ����s���Ă���
                // ��ʃT�C�Y 1920*1080 �Ȃ�@x:0~1919 y:0~1079 �ɒǉ��̕ϊ��������
                float4 vertex : SV_POSITION;
            };

            // uniform�ϐ��̓O���[�o���ϐ��ɋ߂��d�g��
            // �V�F�[�_�[�̊O��(C#�X�N���v�g)����f�[�^��n�����Ƃ��ł���
            // Unity��ł�Uniform�ϐ����܂Ƃ߂��\���̂Ō��������鎖������ ConstantBuffer(CBuffer)
            //uniform sampler2D _MainTex;

            // sampler2D�^�̕ϐ�����Properties�u���b�N��Texure2D�Ɠ����Ȃ̂Œl���n�����
            sampler2D _MainTex;
            // _ST�Ƃ����ϐ�����t����ƁATiling(x, y)��Offest(z, w)���n����Ă���
            // �s�v�Ȃ�錾���Ȃ��Ă��悢
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

            // �����܂ł�Cg����̃v���O�������Ƃ������}
            ENDCG
        }
    }
    // FallBack�u���b�N�cSubShader�u���b�N�����s�ł��Ȃ������ꍇ�Ɏ��s�����u���b�N
    FallBack off
}
