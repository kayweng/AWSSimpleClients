using Amazon.APIGateway;
using Amazon.AutoScaling;
using Amazon.CloudFormation;
using Amazon.CloudFront;
using Amazon.CloudWatch;
using Amazon.CognitoIdentity;
using Amazon.CognitoSync;
using Amazon.DynamoDBv2;
using Amazon.EC2;
using Amazon.ElastiCache;
using Amazon.IdentityManagement;
using Amazon.Kinesis;
using Amazon.Lambda;
using Amazon.Route53;
using Amazon.S3;
using Amazon.SimpleNotificationService;
using Amazon.SimpleWorkflow;
using Amazon.SQS;

namespace AWSClients
{
    public abstract class AbstactAmazonServiceCreator
    {
        public abstract IAmazonDynamoDB CreateDynamoDBClient();

        public abstract IAmazonS3 CreateS3Client();

        public abstract IAmazonLambda CreateLambdaClient();

        public abstract IAmazonCognitoIdentity CreateCognitoIdentityClient();

        public abstract IAmazonAPIGateway CreateAPIGatewayClient();

        public abstract IAmazonCloudWatch CreateCloudWatchClient();

        public abstract IAmazonRoute53 CreateRoute53Client();

        public abstract IAmazonSQS CreateSQSClient();

        public abstract IAmazonSimpleNotificationService CreateSNSClient();

        public abstract IAmazonAutoScaling CreateAutoScalingClient();

        public abstract IAmazonCloudFormation CreateCloudFormationClient();

        public abstract IAmazonCloudFront CreateCloudFrontClient();

        public abstract IAmazonCognitoSync CreateCognitoSyncClient();

        public abstract IAmazonEC2 CreateEC2Client();

        public abstract IAmazonElastiCache CreateElasticCacheClient();

        public abstract IAmazonIdentityManagementService CreateAIMClient();

        public abstract IAmazonKinesis CreateKinesisClient();

        public abstract IAmazonSimpleWorkflow CreateSimpleWorkflowClient();

    }
}
