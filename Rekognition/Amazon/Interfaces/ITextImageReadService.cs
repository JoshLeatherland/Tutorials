using Amazon.Rekognition.Model;

namespace Amazon.Interfaces
{
    public interface ITextImageReadService
    {
        /// <summary>
        /// Detects and reads text in an image stored in an Amazon S3 bucket.
        /// </summary>
        /// <param name="bucket">The name of the S3 bucket containing the image.</param>
        /// <param name="key">The object key (file name) of the image in the S3 bucket.</param>
        /// <returns>
        /// A <see cref="DetectTextResponse"/> containing details about the detected text elements.
        /// </returns>
        /// <exception cref="InvalidParameterException">
        /// Thrown when no text is detected in the provided image.
        /// </exception>
        /// <remarks>
        /// <para><b>Required IAM Permissions:</b></para>
        /// <list type="bullet">
        ///   <item><description><c>rekognition:DetectText</c></description></item>
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
        ///       "Action": [ "rekognition:DetectText" ],
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
        Task<DetectTextResponse> ReadTextFromImage(string bucket, string key);
    }
}
