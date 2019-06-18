Shader "Unlit/test5"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_ControlPoint ("Control point", vector) = (1, 1,1,1)
		_ControlPoint2("Control point", vector) = (1, 1,1,1)
		_ControlPoint3("Control point", vector) = (1, 1,1,1)
		_ControlPoint4("Control point", vector) = (1, 1,1,1)
		_Speed("Speed",float) = 5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100
		Cull Off 

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
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
			float _Speed;
			float2 _ControlPoint;
			float2 _ControlPoint2;
			float2 _ControlPoint3;
			float2 _ControlPoint4;
			//float theta;
            v2f vert (appdata v)
            {
				v2f o;
				//float3 begin = float3(-0.5, v.vertex.y, v.vertex.z);
				//float3 end = float3(0.5, v.vertex.y, v.vertex.z);

				//float vertX = v.vertex.x + 0.5;

				//v.vertex.xyz = (1 - vertX) * (1 - vertX) * begin.xyz
				//	+ 2.0 * (1 - vertX) * vertX * _ControlPoint.xyz;
				//+vertX * vertX * end.xyz;
				float2 p0 = _ControlPoint;
				float2 p1 = _ControlPoint2;
				float2 p2 = _ControlPoint3;
				float2 p3 = _ControlPoint4;
				float theta = _Time[1] * _Speed;
				float t = v.vertex.x/10+0.5;
				p1 = (p1[0] -sin(theta), sin(theta));
				p2 = (p2[0] +sin((theta + 30)), p2[1] - sin((theta + 30)));
				
				float2 p = (1 - t) * (1 - t) * (1 - t) * p0 + 3 * (1 - t) * (1 - t) * t * p1 + 3 * (1 - t) * t * t * p2 + t * t * t * p3;

				v.vertex.y = p.y;

				
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
            ENDCG
        }
    }
}
