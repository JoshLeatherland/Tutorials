using Amazon.Interfaces;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;

namespace Amazon
{
    public class TextImageReadService(IAmazonRekognition rekognition) : ITextImageReadService
    {
        private readonly IAmazonRekognition _rekognition = rekognition;

        public async Task<DetectTextResponse> ReadTextFromImage(string bucket, string key)
        {
            var request = new DetectTextRequest
            {
                Image = new Image
                {
                    S3Object = new S3Object
                    {
                        Bucket = bucket,
                        Name = key
                    }
                }
            };

            var response = await _rekognition.DetectTextAsync(request);

            return response;
        }
    }
}
