Shader "Little Polygon/Simple Outline" {
	Properties {
		_Color ("Main Color", Color) = (1.0, 1.0, 1.0, 1.0)
		_OutlineColor ("Outline Color", Color) = (1.0, 1.0, 1.0, 1.0)
		_Outline ("Outline Width", Float) = 1.0
		_MainTex ("Main Texture", 2D) = "white" {}
	}
	SubShader {
		Tags { "Queue" = "Geometry" }
		Lighting Off Fog { Mode Off }
		Pass {
CGPROGRAM
#pragma exclude_renderers ps3 xbox360 flash
#pragma fragmentoption ARB_precision_hint_fastest
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"

uniform fixed4 _Color;
uniform sampler2D _MainTex;
uniform float4 _MainTex_ST;

struct FragmentInput {
	float4 pos : SV_POSITION;
	half2 uv : TEXCOORD0;
};

FragmentInput vert(
	float4 vertex : POSITION,
	float4 texcoord : TEXCOORD0
) {						
	FragmentInput o;
	o.pos = mul(UNITY_MATRIX_MVP, vertex);
	o.uv = TRANSFORM_TEX( texcoord, _MainTex );
	return o;
}

half4 frag(FragmentInput i) : COLOR {
	return _Color * tex2D( _MainTex, i.uv );
}

ENDCG
		} 	
		Pass {
			ZTest Less Cull Front 
			Offset 10, 100
			
CGPROGRAM
#pragma exclude_renderers ps3 xbox360 flash
#pragma fragmentoption ARB_precision_hint_fastest
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"

uniform fixed4 _OutlineColor;
uniform float _Outline;

float4 vert (
	float4 vertex : POSITION,
	float3 normal : NORMAL
) : SV_POSITION {

	//float4 pos = mul( UNITY_MATRIX_MVP, vertex); 
	//float3 norm = mul ((float3x3)UNITY_MATRIX_MV, normal);
	//norm.x *= UNITY_MATRIX_P[0][0];
    //norm.y *= UNITY_MATRIX_P[1][1];	
    //pos.xy += norm.xy * _Outline;
    //return pos;

	float4 pos = mul( UNITY_MATRIX_MV, vertex); 
	normal = mul( (float3x3)UNITY_MATRIX_IT_MV, normal);  
	normal.z = -0.5;
	pos = pos + float4(normalize(normal),0) * _Outline;
	return mul(UNITY_MATRIX_P, pos);
}

half4 frag() : COLOR {
	return _OutlineColor;
}

ENDCG
		}
	}
	FallBack "Diffuse"
}
