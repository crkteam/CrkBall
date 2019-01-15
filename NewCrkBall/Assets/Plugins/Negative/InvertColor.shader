// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'
Shader "Sprites/SpritesInvertColor"
{
	Properties
	{
	_Color("Tint", Color) = (1,1,1,1)
		_InvertColors("Invert Colors", Range(0,1)) = 0
	}

		SubShader
	{
		Tags
	{
		"RenderType" = "Transparent"
	}
		Blend One OneMinusSrcAlpha
		Pass
	{
		CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"

		struct appdata_t
	{
		float4 vertex   : POSITION;
		float4 color    : COLOR;
		float2 texcoord : TEXCOORD0;
	};

	struct v2f
	{
		float4 vertex   : SV_POSITION;
		fixed4 color : COLOR;
		float2 texcoord  : TEXCOORD0;
	};

	fixed4 _Color;

	v2f vert(appdata_t IN)
	{
		v2f OUT;
		OUT.vertex = UnityObjectToClipPos(IN.vertex);
		OUT.texcoord = IN.texcoord;
		OUT.color = IN.color * _Color;
		return OUT;
	}

	sampler2D _MainTex;
	float _InvertColors;

	fixed4 SampleSpriteTexture(float2 uv)
	{
		fixed4 color = tex2D(_MainTex, uv);
		return color;
	}

	fixed4 frag(v2f IN) : SV_Target
	{
		fixed4 c = SampleSpriteTexture(IN.texcoord) * IN.color;

	if (_InvertColors == 1)
	{
		c.rgb = (1 - c);
	}
	c.rgb *= c.a;
	return c;
	}
		ENDCG
	}
	}
}