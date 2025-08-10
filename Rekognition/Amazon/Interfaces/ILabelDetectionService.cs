using Amazon.Rekognition.Model;

namespace Amazon.Interfaces
{
    public interface ILabelDetectionService
    {
        /// <summary>
        /// Detects labels (objects, scenes, and concepts) in an image stored in an Amazon S3 bucket.
        /// </summary>
        /// <param name="bucket">The name of the S3 bucket containing the image.</param>
        /// <param name="key">The object key (file name) of the image in the S3 bucket.</param>
        /// <param name="maximumLabels">The maximum number of labels to return in the response.</param>
        /// <returns>
        /// A <see cref="DetectLabelsResponse"/> containing the detected labels with confidence scores.
        /// </returns>
        /// <exception cref="InvalidParameterException">
        /// Thrown when no labels are detected in the provided image.
        /// </exception>
        /// <remarks>
        /// <para><b>Required IAM Permissions:</b></para>
        /// <list type="bullet">
        ///   <item><description><c>rekognition:DetectLabels</c></description></item>
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
        ///       "Action": [ "rekognition:DetectLabels" ],
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
        Task<DetectLabelsResponse> DetectLabels(string bucket, string key, int maximumLabels);
    }
}
