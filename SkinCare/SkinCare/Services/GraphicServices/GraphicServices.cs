using FFImageLoading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SkinCare.Services.GraphicServices
{
    public class GraphicsService
    {
        private readonly IImageService _imageService;

        public GraphicsService(IImageService imageService) => _imageService = imageService;

        public async Task PreloadImages()
        {
            var resources = Assembly.GetExecutingAssembly().GetManifestResourceNames()
                .Where(x => x.StartsWith("SkinCare.Resources.Images"));

            foreach (var item in resources)
            {
                await _imageService.LoadEmbeddedResource($"{item}", typeof(App).GetTypeInfo().Assembly)
                    .DownSample()
                    .PreloadAsync()
                    .ConfigureAwait(false);
            }
        }
    }
}

