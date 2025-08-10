using Amazon.Interfaces;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;

namespace Amazon
{
    public class FaceDetectionService(IAmazonRekognition rekognition) : IFaceDetectionService
    {
        private readonly IAmazonRekognition _rekognition = rekognition;

        public async Task<DetectFacesResponse> DetectFace(string bucketName, string key)
        {
            var request = new DetectFacesRequest
            {
                Image = new Image
                {
                    S3Object = new S3Object
                    { 
                        Bucket = bucketName,
                        Name = key,
                    }
                },
                Attributes = ["ALL"]
            };

            var response = await _rekognition.DetectFacesAsync(request);

            return response;
        }
    }
}
