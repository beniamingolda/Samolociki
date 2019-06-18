// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

// Unlit shader. Simplest possible textured shader.
// - no lighting
// - no lightmap support
// - no per-material color

Shader "Unlit/test4" {
Properties {
    _MainTex ("Base (RGB)", 2D) = "white" {}
_Dist("dist", float) = 1
_Amp("amp", float)=1
_Speed("speed", float)=1
_Amount("amount", range(0.0,1.0)) = 1
_Color("Color", Color) = (1,1,1,1)
}

SubShader {
    //Tags { "RenderType"="Opaque" }
    //LOD 100

		Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
		LOD 100
		Blend One One
		Zwrite Off
		Cull Back
    Pass {
        CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata_t {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct v2f {
                float4 vertex : SV_POSITION;
                float2 texcoord : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                UNITY_VERTEX_OUTPUT_STEREO
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
			float _Dist;
			float _Amp;
			float _Speed;
			float _Amount;
			float4 _Color;

            v2f vert (appdata_t v)
            {
                v2f o;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
				v.vertex.y += sin(_Time.y * _Speed + v.vertex.x* _Amp)*_Dist;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.texcoord) + _Color;
                UNITY_APPLY_FOG(i.fogCoord, col);
                UNITY_OPAQUE_ALPHA(col.a);
                return col;
            }
        ENDCG
    }
}

}
