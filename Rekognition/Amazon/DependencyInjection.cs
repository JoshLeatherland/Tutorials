using Amazon.Interfaces;
using Amazon.Rekognition;
using Microsoft.Extensions.DependencyInjection;

namespace Amazon
{
    public static class DependencyInjection
    {
        /// <summary>
        /// This registers all of our services and Rekognition itself, so we can register all these in our main program.cs
        /// with the below line.
        /// <code>
        /// builder.Services.AddAmazon();
        /// </code>
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddAmazon(this IServiceCollection services)
        {
            services.AddSingleton<IAmazonRekognition>(sp => new AmazonRekognitionClient(RegionEndpoint.EUWest2));

            services.AddSingleton<IFaceComparisonService, FaceComparisonService>();
            services.AddSingleton<IFaceDetectionService, FaceDetectionService>();
            services.AddSingleton<ILabelDetectionService, LabelDetectionService>();
            services.AddSingleton<ITextImageReadService, TextImageReadService>();
            services.AddSingleton<IPpeDetectionService, PpeDetectionService>();

            return services;
        }
    }
}
