using Amazon.Rekognition.Model;

namespace Amazon.Interfaces
{
    public interface IFaceComparisonService
    {
        /// <summary>
        /// Compares a source face image with one or more faces in a target image stored in Amazon S3.
        /// </summary>
        /// <param name="bucket">The name of the S3 bucket containing both the source and target images.</param>
        /// <param name="sourcePhoto">The object key (file name) of the source image in the S3 bucket.</param>
        /// <param name="targetPhoto">The object key (file name) of the target image in the S3 bucket.</param>
        /// <returns>A <see cref="CompareFacesResponse"/> containing match results, including bounding boxes and similarity scores.</returns>
        /// <exception cref="InvalidParameterException">
        /// Thrown when no matching faces are detected in the provided images.
        /// </exception>
        /// <remarks>
        /// <para><b>Required IAM Permissions:</b></para>
        /// <list type="bullet">
        ///   <item><description><c>rekognition:CompareFaces</c></description></item>
        ///   <item><description><c>s3:GetObject</c> (if using S3 storage)</description></item>
        /// </list>
        ///
        /// <para><b>Example Policy:</b></para>
        /// <code>
        /// {
        ///   "Version": "2012-10-17",
        ///   "Statement": [
        ///     {
        ///       "Effect": "Allow",
        ///       "Action": [ "rekognition:CompareFaces" ],
        ///       "Resource": "*"
        ///     },
        ///     {
        ///       "Effect": "Allow",
        ///       "Action": [ "s3:GetObject" ],
        ///       "Resource": "arn:aws:s3:::your-bucket-name/*"
        ///     }
        ///   ]
        /// }
        /// </code>
        /// </remarks>
        Task<CompareFacesResponse> CompareFaces(string bucket, string sourcePhoto, string targetPhoto);
    }
}
