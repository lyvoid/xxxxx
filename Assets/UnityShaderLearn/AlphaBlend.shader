// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Custom/AlphaBlend" {
	Properties {
        _Color ("Color Tint", Color) = (1, 1, 1, 1)
        _MainTex ("Main Tex", 2D) = "white" {}
        _AlphaScale("Alpha Scale", Range(0, 1)) = 1
	}
	SubShader {
        Tags{"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
        
        //Pass {
        //    ZWrite On
        //    ColorMask 0 //不输出颜色信息， 这种做法模型之间的半透明并不会叠加，只是能得到一个模型内部正确的前后关系
        //}
        
        Pass{
            Tags{"LightMode"="ForwardBase"}
            ZWrite Off
            Cull Off // cull off 的时候，采用Zwrite On 是没有什么卵用的，因为后面肯定会被前面覆盖
            Blend SrcAlpha OneMinusSrcAlpha
            
            CGPROGRAM
            
            #pragma vertex vert
            #pragma fragment frag
            #include "Lighting.cginc"
            
            fixed4 _Color;
            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed _AlphaScale;
            
            struct a2v{
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 texcoord : TEXCOORD0;
            };
            
            struct v2f{
                float4 pos : SV_POSITION;
                float3 worldNormal : TEXCOORD0;
                float3 worldPos : TEXCOORD1;
                float2 uv : TEXCOORD2;
            };
            
            v2f vert(a2v v){
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                
                //o.worldNormal = mul(v.normal, (float3x3)unity_WorldToObject);
                o.worldNormal = mul((float3x3)unity_ObjectToWorld, v.normal);
                
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                
                o.uv = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
                // o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                
                return o;
            }
            
            fixed4 frag(v2f i) : SV_Target{
                
                fixed3 worldNormal = normalize(i.worldNormal);
                fixed3 worldLightDir = normalize(UnityWorldSpaceLightDir(i.worldPos));
                
                fixed4 texColor = tex2D(_MainTex, i.uv);
                
                // clip(texColor.a - _AlphaScale);
                // if ((texColor.a - _AlphaScale) < 0.0)
                //  discard;
                
                fixed3 albedo = texColor.rgb * _Color.rgb;
                
                fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz * albedo;
                
                fixed3 diffuse = _LightColor0.rgb * albedo * saturate(
                    dot(worldNormal, worldLightDir));
                
                    
                fixed3 color = ambient + diffuse;
            
                return fixed4(color, texColor.a * _AlphaScale);
            }
            
            ENDCG
            
        }
    
	}
	FallBack "Transparent/VertexLit"
}
