Shader "Geometry/NewGeometryShader"
{
	Properties
	{
		_MainTex("Base (RGB) Trans (A)", 2D) = "white" {}
		_Alpha("Alpha", Range(0.0, 1.0)) = 0.7
		_PressZone("PressZone", Range(0.0, 0.5)) = 0.001
	}

	SubShader
	{
		Tags {"Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent"}
		LOD 100

		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma geometry geom
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				fixed4 color : COLOR;
			};

			struct v2g
			{
				float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;
				fixed4 color : COLOR;
			};

			struct g2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
				fixed4 color : COLOR;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float2 _MousePos;
			float2 _MousePosGlobal;
			float _currentPower;
			float _Alpha;
			float _CurrentAlpha;
			float _PressZone;

			v2g vert(appdata v)
			{
				v2g o;
				o.vertex = v.vertex;
				o.uv = v.uv;
				o.color = v.color;
				return o;
			}

			[maxvertexcount(3)]
			void geom(triangle v2g IN[3], inout TriangleStream<g2f> triStream)
			{
				g2f o;
				float alpha = 0;
				for (int i = 0; i < 3; i++)
				{
					alpha += IN[i].color.a;
				}
				alpha /= 3;
				for (int i = 0; i < 3; i++)
				{
					o.vertex = UnityObjectToClipPos(IN[i].vertex);
					UNITY_TRANSFER_FOG(o,o.vertex);
					o.uv = TRANSFORM_TEX(IN[i].uv, _MainTex);
					o.color = (0,0,0,alpha);
					triStream.Append(o);

					
				}
				

				triStream.RestartStrip();
			}

			fixed4 frag(g2f i) : SV_Target
			{
				//_pressedPower = 0;
				float2 uv = i.uv;
				//float4 col = tex2D(_MainTex, uv);



				//float2 center = _MousePos;
				float2 dir = normalize(_MousePos - uv);
				float d = length(_MousePos - uv);

				float factor = _PressZone * sin(_currentPower); //_currentPower _Time.y
				float f = exp(factor * (d - .5)) - 1.;
				//float f = exp(0.5 * (d - .5)) - 1.;
				if (d > .5) f = 0.; //*/
				float4 col = tex2D(_MainTex, uv + f * dir);

				//col.a = i.color.a;
				//col = i.color;
				if (col.a > _Alpha || i.color.a > 0.95)
					col.a = _Alpha;//*/

				return col;
		}
		ENDCG
	}
	}
}