Shader "Custom/l2xin/T_AlphaTest"
{
    Properties 
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Cutoff("Alhpa Cutoff", Range(0,1)) = 0.5
    }
    
    SubShader
    {
        Tags { "Queue"="AlphaTest" "IgnoreProjector"="True" "RenderType"="TransparentCutout"}
        
        Pass
        {
            Tags { "LightMode"="ForwardBase" }
            
            CGPROGRAM

            
            #pragma vertex vert
            #pragma fragment frag
            
            #include "Lighting.cginc"
            
            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed _Cutoff;            
            
            struct a2v{
                float4 vertex : POSITION;
                float4 texcoord: TEXCOORD0;
            };
            
            struct v2f{
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };
            
            v2f vert(a2v v){
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                return o;
            }
            
            fixed4 frag(v2f i) :SV_Target{
                fixed4 texColor = tex2D(_MainTex, i.uv);
                //AlphaTest通过判断clip函数的参数，如果小于0本次fragment discard.
                clip(texColor.a - _Cutoff);
                return texColor;
            }
        
            ENDCG
        }
    }
    FallBack "Diffuse"
}