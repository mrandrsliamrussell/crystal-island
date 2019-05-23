Shader "Custom/L_LakeShader" {
	Properties{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
	_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
		_BumpMap("Bumpmap", 2D) = "bump" {}
	_Alpha("alpha", Range(0,1)) = 0.0
		_Scale("scale", float) = 1
		_Speed("speed", float) = 1
		_Frequency("frequency", float) = 1
		_ScrollXSpeed("X", Range(-10,10)) = 0
		_ScrollYSpeed("Y", Range(-10,10)) = 0
		_BumpPower("normal strength", Range(0,1)) = 1

	}
		SubShader{
		Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" }
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
#pragma surface surf Standard fullforwardshadows alpha
#pragma vertex vert

		// Use shader model 3.0 target, to get nicer looking lighting
#pragma target 3.0
#pragma multi_compile_fog
#include "UnityCG.cginc"

		sampler2D _MainTex;
	sampler2D _BumpMap;
	float _Alpha;
	float _Scale, _Speed, _Frequency;
	float _BumpPower;


	struct Input {
		float2 uv_MainTex;
		float2 uv_BumpMap;
		float uv_Alpha;
		float _Scale, _Speed, _Frequency;
		half offsetVert;
		float _ScrollXSpeed;
		float _ScrollYSpeed;
		float _BumpPower;
	};

	half _Glossiness;
	half _Metallic;
	fixed4 _Color;
	float _ScrollXSpeed;
	float _ScrollYSpeed;


	void vert(inout appdata_full v) {

		half offsetVert = -(v.vertex.x * v.vertex.x) - (v.vertex.y * v.vertex.y);
		half value = _Scale * sin(_Time.w * _Speed + offsetVert * _Frequency) / 100;
		v.vertex.z += value;
		v.normal.x += value;




	}

	void surf(Input IN, inout SurfaceOutputStandard o) {
		// Albedo comes from a texture tinted by color
		float2 scrolledUV = IN.uv_MainTex;
		float2 scrolledNorm = IN.uv_BumpMap;
		float xScrollValue = _Time * _ScrollXSpeed;
		float yScrollValue = _Time * _ScrollYSpeed;

		scrolledUV += fixed2(xScrollValue.x, xScrollValue.x);
		scrolledNorm += fixed2(yScrollValue.x, yScrollValue.x);
		fixed4 c = tex2D(_MainTex, scrolledUV) * _Color;
		o.Albedo = c.rgb;
		// Metallic and smoothness come from slider variables
		o.Metallic = _Metallic;
		o.Smoothness = _Glossiness;
		o.Alpha = _Alpha;

		o.Normal = lerp(UnpackNormal(tex2D(_BumpMap, scrolledNorm)), fixed3(0, 0, 1), -_BumpPower + 1);
	}
	ENDCG
	}
		FallBack "Diffuse"
}

