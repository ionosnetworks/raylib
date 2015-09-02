#version 330

in vec2 fragTexCoord;

out vec4 fragColor;

uniform sampler2D texture0;
uniform vec4 tintColor;

// NOTE: Add here your custom variables 

float hatchOffsetY = 5.0f;
float lumThreshold01 = 0.9f;
float lumThreshold02 = 0.7f;
float lumThreshold03 = 0.5f;
float lumThreshold04 = 0.3f;

void main()
{
    vec3 tc = vec3(1.0, 1.0, 1.0);
    float lum = length(texture2D(texture0, fragTexCoord).rgb);

    if (lum < lumThreshold01) 
    {
        if (mod(gl_FragCoord.x + gl_FragCoord.y, 10.0) == 0.0) tc = vec3(0.0, 0.0, 0.0);
    }

    if (lum < lumThreshold02) 
    {
        if (mod(gl_FragCoord .x - gl_FragCoord .y, 10.0) == 0.0) tc = vec3(0.0, 0.0, 0.0);
    }

    if (lum < lumThreshold03) 
    {
        if (mod(gl_FragCoord .x + gl_FragCoord .y - hatchOffsetY, 10.0) == 0.0) tc = vec3(0.0, 0.0, 0.0);
    }

    if (lum < lumThreshold04) 
    {
        if (mod(gl_FragCoord .x - gl_FragCoord .y - hatchOffsetY, 10.0) == 0.0) tc = vec3(0.0, 0.0, 0.0);
    }

    fragColor = vec4(tc, 1.0);
}