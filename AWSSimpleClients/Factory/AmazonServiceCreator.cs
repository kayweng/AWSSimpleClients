using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using System;
using System.Collections.Generic;
using Amazon.S3;
using Amazon.Lambda;
using Amazon.APIGateway;
using Amazon.CloudWatch;
using Amazon.CognitoIdentity;
using Amazon.Route53;
using Amazon.SQS;
using Amazon.AutoScaling;
using Amazon.CloudFormation;
using Amazon.CloudFront;
using Amazon.CognitoSync;
using Amazon.EC2;
using Amazon.IdentityManagement;
using Amazon.Kinesis;
using Amazon.SimpleNotificationService;
using Amazon.SimpleWorkflow;
using Amazon.ElastiCache;

namespace AWSClients
{
    public class AmazonServiceCreator : AbstactAmazonServiceCreator
    {
        protected string AccessKey { get; set; }

        protected string SecretKey { get; set; }

        public RegionEndpoint AWSRegion { get; set; }

        public AWSCredentials Credentials { get; set; }

        #region Constructor
        public AmazonServiceCreator()
        {
        
        }

        public AmazonServiceCreator(RegionEndpoint region,string accesSKey, string secretKey)
        {
            AccessKey = accesSKey;
            SecretKey = secretKey;

            AWSRegion = region;

            Credentials = new BasicAWSCredentials(accessKey: AccessKey, secretKey: SecretKey);
        }

        public void LoadAwsCredentialsProfile(RegionEndpoint region, string location, string name= "default")
        {
            AWSRegion = region;

            Credentials = GetAWSCredentialsFromProfile(location, name);
        }
        #endregion

        #region Create Clients
        public override IAmazonDynamoDB CreateDynamoDBClient()
        {
            var config = new AmazonDynamoDBConfig
            {
                RegionEndpoint = AWSRegion,
            };

            return new AmazonDynamoDBClient(Credentials, config);
        }

        public override IAmazonS3 CreateS3Client()
        {
            var config = new AmazonS3Config
            {
                RegionEndpoint = AWSRegion,                 
            };

            return new AmazonS3Client(Credentials, config);
        }

        public override IAmazonLambda CreateLambdaClient()
        {
            var config = new AmazonLambdaConfig()
            {
                RegionEndpoint = AWSRegion
            };

            return new AmazonLambdaClient(Credentials, config);
        }

        public override IAmazonCognitoIdentity CreateCognitoIdentityClient()
        {
            var config = new AmazonCognitoIdentityConfig()
            {
                RegionEndpoint = AWSRegion
            };

            return new AmazonCognitoIdentityClient(Credentials, config);
        }

        public override IAmazonAPIGateway CreateAPIGatewayClient()
        {
            var config = new AmazonAPIGatewayConfig()
            {
                RegionEndpoint = AWSRegion
            };

            return new AmazonAPIGatewayClient(Credentials, config);
        }

        public override IAmazonCloudWatch CreateCloudWatchClient()
        {
            var config = new AmazonCloudWatchConfig()
            {
                RegionEndpoint = AWSRegion
            };

            return new AmazonCloudWatchClient(Credentials, config);
        }

        public override IAmazonRoute53 CreateRoute53Client()
        {
            var config = new AmazonRoute53Config()
            {
                RegionEndpoint = AWSRegion
            };

            return new AmazonRoute53Client(Credentials, config);
        }

        public override IAmazonSQS CreateSQSClient()
        {
            var config = new AmazonSQSConfig()
            {
                RegionEndpoint = AWSRegion
            };

            return new AmazonSQSClient(Credentials, config);
        }

        public override IAmazonSimpleNotificationService CreateSNSClient()
        {
            var config = new AmazonSimpleNotificationServiceConfig()
            {
                RegionEndpoint = AWSRegion
            };

            return new AmazonSimpleNotificationServiceClient(Credentials, config);
        }

        public override IAmazonAutoScaling CreateAutoScalingClient()
        {
            var config = new AmazonAutoScalingConfig()
            {
                RegionEndpoint = AWSRegion
            };

            return new AmazonAutoScalingClient(Credentials, config);
        }

        public override IAmazonCloudFormation CreateCloudFormationClient()
        {
            var config = new AmazonCloudFormationConfig()
            {
                RegionEndpoint = AWSRegion
            };

            return new AmazonCloudFormationClient(Credentials, config);
        }

        public override IAmazonCloudFront CreateCloudFrontClient()
        {
            var config = new AmazonCloudFrontConfig()
            {
                RegionEndpoint = AWSRegion
            };

            return new AmazonCloudFrontClient(Credentials, config);
        }

        public override IAmazonCognitoSync CreateCognitoSyncClient()
        {
            var config = new AmazonCognitoSyncConfig()
            {
                RegionEndpoint = AWSRegion
            };

            return new AmazonCognitoSyncClient(Credentials, config);
        }

        public override IAmazonEC2 CreateEC2Client()
        {
            var config = new AmazonEC2Config()
            {
                RegionEndpoint = AWSRegion
            };

            return new AmazonEC2Client(Credentials, config);
        }

        public override IAmazonIdentityManagementService CreateAIMClient()
        {
            var config = new AmazonIdentityManagementServiceConfig()
            {
                RegionEndpoint = AWSRegion
            };

            return new AmazonIdentityManagementServiceClient(Credentials, config);
        }

        public override IAmazonKinesis CreateKinesisClient()
        {
            var config = new AmazonKinesisConfig()
            {
                RegionEndpoint = AWSRegion
            };

            return new AmazonKinesisClient(Credentials, config);
        }

        public override IAmazonSimpleWorkflow CreateSimpleWorkflowClient()
        {
            var config = new AmazonSimpleWorkflowConfig()
            {
                RegionEndpoint = AWSRegion
            };

            return new AmazonSimpleWorkflowClient(Credentials, config);
        }

        public override IAmazonElastiCache CreateElasticCacheClient()
        {
            var config = new AmazonElastiCacheConfig()
            {
                RegionEndpoint = AWSRegion
            };

            return new AmazonElastiCacheClient(Credentials, config);
        }

        #endregion

        #region Private
        private static AWSCredentials GetAWSCredentialsFromProfile(string profileLocation, string profileName = "default")
        {
            var credentialProfileStoreChain = new CredentialProfileStoreChain();
            
            if (credentialProfileStoreChain.TryGetAWSCredentials(profileName, out AWSCredentials defaultCredentials))
            {
                return defaultCredentials;
            }
            else
            {
                throw new AmazonClientException("Unable to find a default profile in CredentialProfileStoreChain.");
            }
        }
        #endregion
    }
}
