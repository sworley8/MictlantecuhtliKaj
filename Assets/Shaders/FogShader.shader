Shader "Custom/FogShader"
{
    Properties
    {
		_MainTex ("texture", 2D) = "white" {}
		_FogColor("Fog Color", Color) = (1,1,1,1)
		_FarPlane("Far Plane", float) = 20
	}
	SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			sampler2D _CameraDepthTexture;
			fixed4 _FogColor;
			float _FarPlane;

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				float4 scrPos :	TEXCOORD1;
				float3 worldPos : TEXCOORD2;

			};

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.scrPos = ComputeScreenPos(o.vertex);
				o.worldPos = mul( unity_ObjectToWorld , v.vertex );
				o.uv = v.uv;
				return o;
			}

			sampler2D _MainTex;

			fixed4 frag(v2f i) : COLOR
			{
				float camDist = distance(i.worldPos, _WorldSpaceCameraPos);
				float dist = clamp(camDist, 0, _FarPlane);
				float trans01Dist = dist / _FarPlane;
				float depthvalue = Linear01Depth(tex2Dproj(_CameraDepthTexture, i.scrPos).r);
				fixed4 fogColor = _FogColor * depthvalue;
				fixed4 val = fixed4(depthvalue, depthvalue, depthvalue, 1);
				fixed4 col = tex2Dproj(_MainTex, i.scrPos);
				return lerp(col,fogColor,depthvalue);
				//return fixed4(trans01Dist, trans01Dist, trans01Dist,1) * col;
			}
			ENDCG
		}
	}
}
