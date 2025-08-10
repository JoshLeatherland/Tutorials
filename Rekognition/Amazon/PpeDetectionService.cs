using Amazon.Interfaces;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;

namespace Amazon
{
    public class PpeDetectionService(IAmazonRekognition rekognition) : IPpeDetectionService
    {
        private readonly IAmazonRekognition _rekognition = rekognition;

        public async Task<DetectProtectiveEquipmentResponse> DetectPpe(string bucketName, string key)
        {
            var request = new DetectProtectiveEquipmentRequest
            {
                Image = new Image
                {
                    S3Object = new S3Object
                    {
                        Bucket = bucketName,
                        Name = key
                    }
                }
            };

            return await _rekognition.DetectProtectiveEquipmentAsync(request);
        }
    }
}
