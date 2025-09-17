using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.RenderGraphModule.Util;

public class TestRendererfeature : ScriptableRendererFeature
{
    class TestRenderPass : ScriptableRenderPass
    {
        private Material material;
        
        private TextureDesc descriptor;
        
        public TestRenderPass(Material material)
        {
            this.material = material;
        }
        
        // RecordRenderGraph is where the RenderGraph handle can be accessed, through which render passes can be added to the graph.
        // FrameData is a context container through which URP resources can be accessed and managed.
        public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
        {
            UniversalResourceData resourceData = frameData.Get<UniversalResourceData>();

            TextureHandle depthTextureSource = resourceData.cameraNormalsTexture;  
            descriptor = resourceData.activeColorTexture.GetDescriptor(renderGraph);
            descriptor.name = "Depth Texture";
            descriptor.depthBufferBits = 0;
            var destination = renderGraph.CreateTexture(descriptor);

            RenderGraphUtils.BlitMaterialParameters parameters = new(depthTextureSource, destination, material, 0);
            renderGraph.AddBlitPass(parameters,"DepthTexture");
            
            resourceData.cameraColor = destination;
        }
    }

    TestRenderPass m_ScriptablePass;
    [SerializeField] private Material material;
    

    /// <inheritdoc/>
    public override void Create()
    {
        m_ScriptablePass = new TestRenderPass(material);

        // Configures where the render pass should be injected.
        m_ScriptablePass.renderPassEvent = RenderPassEvent.AfterRenderingPostProcessing;
    }

    // Here you can inject one or multiple render passes in the renderer.
    // This method is called when setting up the renderer once per-camera.
    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        renderer.EnqueuePass(m_ScriptablePass);
    }
}
