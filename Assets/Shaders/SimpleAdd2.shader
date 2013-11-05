Shader "Little Polygon/Simple (Additive) 2" {
	Properties {
		_Color ("Main Color", Color) = (1.0, 1.0, 1.0, 1.0)
		_MainTex ("Main Texture", 2D) = "white" {}
	}
	SubShader {
		Tags { "Queue" = "Transparent+100" }
		Lighting Off Fog { Mode Off }
		Blend SrcAlpha One
		ZTest Off
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
	fixed4 color : COLOR;
};

FragmentInput vert(
	float4 vertex : POSITION,
	float4 color : COLOR,
	float4 texcoord : TEXCOORD0
) {						
	FragmentInput o;
	o.pos = mul(UNITY_MATRIX_MVP, vertex);
	o.uv = TRANSFORM_TEX( texcoord, _MainTex );
	o.color = color;
	return o;
}

half4 frag(FragmentInput i) : COLOR {
	return i.color * _Color * tex2D( _MainTex, i.uv );
}

ENDCG

		} 	
	}
	FallBack "Diffuse"
}
