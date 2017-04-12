 Shader "Custom/FlatShaderWithTexture" {
 Properties {
 	 _Color ("Main Color", Color) = (1,1,1,1)
     _MainTex ("Base (RGB)", 2D) = "white" {}
 }
 
 SubShader {
 	Pass { Color [_Color] }
	
CGPROGRAM
// Uses the NoLighting model
#pragma surface surf NoLighting

sampler2D _MainTex; // The input texture

struct Input {
    float2 uv_MainTex;
};

void surf (Input IN, inout SurfaceOutput o) {
    o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;

}

fixed4 LightingNoLighting(SurfaceOutput s, fixed3 lightDir, fixed atten)
 {
     fixed4 c;
     c.rgb = s.Albedo; 
     c.a = s.Alpha;
     return c;
 }


ENDCG

}

}