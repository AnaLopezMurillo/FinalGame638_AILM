using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[System.Serializable]
[PostProcess(typeof(PixelateRenderer), PostProcessEvent.AfterStack, "Custom/PixelationShader")]
public sealed class Pixelate : PostProcessEffectSettings
{
    [Range(1, 1024), Tooltip("Pixelation effect intensity.")]
    public IntParameter pixelSize = new IntParameter { value = 100 };
}

public sealed class PixelateRenderer : PostProcessEffectRenderer<Pixelate>
{
    public override void Render(PostProcessRenderContext context)
    {
        var sheet = context.propertySheets.Get(Shader.Find("Custom/PixelationShader"));
        sheet.properties.SetFloat("_PixelationSize", settings.pixelSize);
        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
}