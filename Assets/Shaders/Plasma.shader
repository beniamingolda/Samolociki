Shader "Unlit/Test3"
{
    Properties
    {
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Noise("Szum", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
		_Amplitude("Amplituda", float) = 10
		_TimeDamper("TimeDamper", float) = 10
		_Frequency("Frequency", float) = 10
		_Position("Position",Range(0,1)) = 0.0


    }
    SubShader
    {
	Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
		LOD 100
		Blend One One
		Zwrite Off
		Cull Back


        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float2 texcoord : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
			fixed4 _Color;
			float _Amplitude;
			float _TimeDamper;
			float _Frequency;
			float _Position;
			float rand;


            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.texcoord + float2(0,_Position + _Amplitude*sin(_Frequency*(i.texcoord.x) + _Time[1] / _TimeDamper) * _Amplitude*sin(_Frequency*3*(i.texcoord.x) + _Time[1] * _TimeDamper))) * _Color;
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
