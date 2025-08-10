using Amazon.Interfaces;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;

namespace Amazon
{
    public class FaceComparisonService(IAmazonRekognition rekognition) : IFaceComparisonService
    {
        private readonly IAmazonRekognition _rekognition = rekognition;

        public async Task<CompareFacesResponse> CompareFaces(string bucket, string sourcePhoto, string targetPhoto)
        {
            var request = new CompareFacesRequest
            {
                SourceImage = new Image
                {
                    S3Object = new S3Object
                    {
                        Bucket = bucket,
                        Name = sourcePhoto
                    }
                },
                TargetImage = new Image
                {
                    S3Object = new S3Object
                    {
                        Bucket = bucket,
                        Name = targetPhoto
                    }
                },
                SimilarityThreshold = 90F // adjust as needed for stricter/looser matching.
            };

            var response = await _rekognition.CompareFacesAsync(request);

            return response;
        }
    }
}
