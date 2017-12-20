using Amazon;
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
using AWSClients;
using System;
using System.IO;

namespace AWSSimpleClients.Clients
{
    public class AWS
    {
        #region Properties
        private static AmazonServiceCreator _creator { get; set; }

        private static IAmazonDynamoDB _dynamoDB { get; set; }

        private static IAmazonS3 _s3 { get; set; }

        private static IAmazonLambda _lambda { get; set; }

        private static IAmazonCognitoIdentity _cognitoIdentity { get; set; }

        private static IAmazonCognitoSync _cognitoSync { get; set; }
        
        private static IAmazonAPIGateway _apiGateway { get; set; }

        private static IAmazonCloudWatch _cloudWatch { get; set; }

        private static IAmazonRoute53 _route53 { get; set; }

        private static IAmazonSQS _sqs { get; set; }

        private static IAmazonSimpleNotificationService _sns { get; set; }

        private static IAmazonAutoScaling _autoScaling { get; set; }

        private static IAmazonCloudFormation _cloudFormation { get; set; }

        private static IAmazonCloudFront _cloudFront { get; set; }

        private static IAmazonEC2 _ec2 { get; set; }

        private static IAmazonElastiCache _elasticCache { get; set; }

        private static IAmazonIdentityManagementService _aim { get; set; }

        private static IAmazonKinesis _kinesis { get; set; }

        private static IAmazonSimpleWorkflow _simpleWorkflow { get; set; }
        #endregion

        #region Constructors

        public AWS()
        {
            if (_creator == null)
            {
                _creator = new AmazonServiceCreator();
            }
        }

        public static IAmazonDynamoDB DynamoDB
        {
            get
            {
                if (_dynamoDB == null)
                {
                    _dynamoDB = _creator.CreateDynamoDBClient();
                }

                return _dynamoDB;
            }
        }

        public static IAmazonS3 S3
        {
            get
            {
                if(_s3 == null)
                {
                    _s3 = _creator.CreateS3Client();
                }

                return _s3;
            }
        }

        public static IAmazonLambda Lambda
        {
            get
            {
                if(_lambda == null)
                {
                    _lambda = _creator.CreateLambdaClient();
                }

                return _lambda;
            }
        }

        public static IAmazonCognitoIdentity CognitoIdentity
        {
            get
            {
                if(_cognitoIdentity == null)
                {
                    _cognitoIdentity = _creator.CreateCognitoIdentityClient();
                }
                return _cognitoIdentity;
            }
        }

        public static IAmazonCognitoSync CognitoSync
        {
            get
            {
                if (_cognitoSync == null)
                {
                    _cognitoSync = _creator.CreateCognitoSyncClient();
                }
                return _cognitoSync;
            }
        }

        public static IAmazonAPIGateway APIGateWay
        {
            get
            {
                if (_apiGateway == null)
                {
                    _apiGateway = _creator.CreateAPIGatewayClient();
                }
                return _apiGateway;
            }
        }

        public static IAmazonCloudWatch CloudWatch
        {
            get
            {
                if (_cloudWatch == null)
                {
                    _cloudWatch = _creator.CreateCloudWatchClient();
                }
                return _cloudWatch;
            }
        }

        public static IAmazonRoute53 Route53
        {
            get
            {
                if (_route53 == null)
                {
                    _route53 = _creator.CreateRoute53Client();
                }
                return _route53;
            }
        }

        public static IAmazonSQS SQS
        {
            get
            {
                if (_sqs == null)
                {
                    _sqs = _creator.CreateSQSClient();
                }
                return _sqs;
            }
        }

        public static IAmazonSimpleNotificationService SNS
        {
            get
            {
                if (_sns == null)
                {
                    _sns = _creator.CreateSNSClient();
                }
                return _sns;
            }
        }

        public static IAmazonAutoScaling AutoScaling
        {
            get
            {
                if (_autoScaling == null)
                {
                    _autoScaling = _creator.CreateAutoScalingClient();
                }
                return _autoScaling;
            }
        }

        public static IAmazonEC2 EC2
        {
            get
            {
                if (_ec2 == null)
                {
                    _ec2 = _creator.CreateEC2Client();
                }
                return _ec2;
            }
        }

        public static IAmazonElastiCache ElasticCache
        {
            get
            {
                if (_elasticCache == null)
                {
                    _elasticCache = _creator.CreateElasticCacheClient();
                }
                return _elasticCache;
            }
        }

        public static IAmazonIdentityManagementService AIM
        {
            get
            {
                if (_aim == null)
                {
                    _aim = _creator.CreateAIMClient();
                }
                return _aim;
            }
        }

        public static IAmazonKinesis Kinesis
        {
            get
            {
                if (_kinesis == null)
                {
                    _kinesis = _creator.CreateKinesisClient();
                }
                return _kinesis;
            }
        }

        public static IAmazonSimpleWorkflow SimpleWorkflow
        {
            get
            {
                if (_simpleWorkflow == null)
                {
                    _simpleWorkflow = _creator.CreateSimpleWorkflowClient();
                }
                return _simpleWorkflow;
            }
        }

        public static IAmazonCloudFormation CloudFormation
        {
            get
            {
                if (_cloudFormation == null)
                {
                    _cloudFormation = _creator.CreateCloudFormationClient();
                }
                return _cloudFormation;
            }
        }

        public static IAmazonCloudFront CloudFront
        {
            get
            {
                if (_cloudFront == null)
                {
                    _cloudFront = _creator.CreateCloudFrontClient();
                }
                return _cloudFront;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initial AWS client creator by provided region and aws profile file.
        /// </summary>
        /// <param name="region"></param>
        /// <param name="profileLocation"></param>
        /// <param name="profileName"></param>
        public static void LoadAwsCredentialsProfile(RegionEndpoint region, string profileLocation, string profileName)
        {
            try
            {
                if (region == null)
                {
                    throw new Exception("Invalid Amazon Region !");
                }

                if (string.IsNullOrEmpty(profileLocation))
                {
                    throw new Exception("Invalid profile file location!");
                }

                if(!File.Exists(profileLocation)){
                    throw new Exception("AWS profile file not found !");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            _creator = AmazonServiceCreator.WithCredentialProfile(region, profileLocation, profileName);
        }

        /// <summary>
        /// Initial AWS Client creator by provided region, access key & region key.
        /// </summary>
        /// <param name="region"></param>
        /// <param name="accessKey"></param>
        /// <param name="secretKey"></param>
        public static void LoadAWSBasicCredentials(RegionEndpoint region, string accessKey, string secretKey)
        {
            try
            {
                if (region == null)
                {
                    throw new Exception("Invalid Amazon Region !");
                }

                if (string.IsNullOrEmpty(accessKey) || string.IsNullOrEmpty(secretKey))
                {
                    throw new Exception("Invalid Access Key or Secret Key !");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            _creator = AmazonServiceCreator.WithAWSKeys(region, accessKey, secretKey);
        }

        #endregion

    }
}
