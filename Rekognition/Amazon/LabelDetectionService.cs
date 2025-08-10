using Amazon.Interfaces;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;

namespace Amazon
{
    public class LabelDetectionService(IAmazonRekognition rekognition) : ILabelDetectionService
    {
        private readonly IAmazonRekognition _rekognition = rekognition;

        public async Task<DetectLabelsResponse> DetectLabels(string bucket, string key, int maximumLabels)
        {
            var request = new DetectLabelsRequest
            {
                Image = new Image
                {
                    S3Object = new S3Object
                    {
                        Bucket = bucket,
                        Name = key
                    }
                },
                MaxLabels = maximumLabels,
                MinConfidence = 75F // example threshold, can be adjusted
            };

            var response = await _rekognition.DetectLabelsAsync(request);

            return response;
        }
    }
}
