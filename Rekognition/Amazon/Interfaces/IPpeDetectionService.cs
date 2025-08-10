using Amazon.Rekognition.Model;

namespace Amazon.Interfaces
{
    public interface IPpeDetectionService
    {
        /// <summary>
        /// Detects the presence of personal protective equipment (PPE) such as face covers, hand covers, and head covers in the image stored in an Amazon S3 bucket.
        /// </summary>
        /// <param name="bucketName">The name of the S3 bucket containing the image.</param>
        /// <param name="key">The object key (file name) of the image in the S3 bucket.</param>
        /// <returns>
        /// A <see cref="DetectProtectiveEquipmentResponse"/> containing details about detected PPE and associated confidence levels.
        /// </returns>
        /// <remarks>
        /// <para><b>Required IAM Permissions:</b></para>
        /// <list type="bullet">
        ///   <item><description><c>rekognition:DetectProtectiveEquipment</c></description></item>
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
        ///       "Action": [ "rekognition:DetectProtectiveEquipment" ],
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
        Task<DetectProtectiveEquipmentResponse> DetectPpe(string bucketName, string key);
    }
}
