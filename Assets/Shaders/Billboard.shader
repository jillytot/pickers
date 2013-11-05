Shader "Little Polygon/Billboard" {
	Properties {
		_Color ("Main Color", Color) = (0, 0, 0, 1.0)
		_MainTex ("Main Texture", 2D) = "white" {}
		_Scale ("Scale", Float) = 1.0
		_Offset ("Offset", Vector) = (0,0,0,0)
	}
	SubShader {
		Tags { "Queue"="Transparent" }
		Lighting Off Cull Off Fog { Mode Off }
		Blend SrcAlpha OneMinusSrcAlpha
		Offset 0, -1000
		ZWrite Off
		
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
uniform float _Scale;
uniform float4 _Offset;

struct FragmentInput {
	float4 pos : SV_POSITION;
	half2 uv : TEXCOORD0;
};

FragmentInput vert(
	float4 vertex : POSITION,
	float4 texcoord : TEXCOORD0
) {						
	FragmentInput o;
	
	float4 basePosition = mul(UNITY_MATRIX_MV, float4(0.0, 0.0, 0.0, 1));
	o.pos = mul(UNITY_MATRIX_P,  
		basePosition +
		_Scale * float4(vertex.xyz, 0) + _Offset
	);

	
	o.uv = TRANSFORM_TEX( texcoord, _MainTex );
	return o;
}

half4 frag(FragmentInput i) : COLOR {
	return _Color * tex2D( _MainTex, i.uv );
}

ENDCG

		} 	
	}
	FallBack "Diffuse"
}
