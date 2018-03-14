using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.SimpleNotificationService.Model;
using AWSSimpleClients.Clients;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading;
using System.IO;

namespace AWSSimpleClientsTest
{
    [TestClass]
    public class SimpleClientTest
    {
        private string _accessKey = "<Your Access Key>";
        private string _secretKey = "<Your Secret Key>";
        private string _testEmail = "<Your test Email>";
        private Amazon.RegionEndpoint _region = Amazon.RegionEndpoint.APSoutheast1;
        
        [TestMethod]
        public void AWSClientWithBasicCredentialsTest()
        {
            AWS.LoadAWSBasicCredentials(_region, _accessKey, _secretKey);

            #region S3

            string bucketName = "awssimpletclienttest-s3bucket";
            //Create Bucket
            var grant = new S3Grant()
            {
                Permission = S3Permission.FULL_CONTROL,
                Grantee = new S3Grantee { EmailAddress = _testEmail }
            };

            var putBucketResponse = AWS.S3.PutBucketAsync(new PutBucketRequest()
            {
                BucketName = bucketName,
                BucketRegion = S3Region.APS1,
                BucketRegionName = "ap-southeast-1",
                Grants = new List<S3Grant>() { grant },
            }).GetAwaiter().GetResult();

            Assert.IsNotNull(putBucketResponse);
            Assert.IsTrue(putBucketResponse.HttpStatusCode == System.Net.HttpStatusCode.OK || putBucketResponse.HttpStatusCode == System.Net.HttpStatusCode.Accepted);

            //Delete Bucket
            var deleteBucketResponse = AWS.S3.DeleteBucketAsync(new DeleteBucketRequest()
            {
                BucketName = bucketName,
                BucketRegion = S3Region.APS1,
                UseClientRegion = true,
            }).GetAwaiter().GetResult();

            Assert.IsNotNull(deleteBucketResponse);

            #endregion

            #region DynamoDB
            string tableName = "AWSSimpleClientDynamoTableTest";
            string hashKey = "Name";

            //Create Table
            var createTableResponse = AWS.DynamoDB.CreateTableAsync(new CreateTableRequest()
            {
                TableName = tableName,
                ProvisionedThroughput = new ProvisionedThroughput
                {
                    ReadCapacityUnits = 3,
                    WriteCapacityUnits = 1
                },
                KeySchema = new List<KeySchemaElement>
                {
                    new KeySchemaElement
                    {
                        AttributeName = hashKey,
                        KeyType = KeyType.HASH
                    }
                },
                AttributeDefinitions = new List<AttributeDefinition>
                {
                    new AttributeDefinition {
                        AttributeName = hashKey,
                        AttributeType = ScalarAttributeType.S
                    }
                }
            }).GetAwaiter().GetResult();

            Assert.IsNotNull(createTableResponse);
            Assert.IsTrue(createTableResponse.HttpStatusCode == System.Net.HttpStatusCode.OK);

            Thread.Sleep(15000);

            //Delete Table
            var deleteTableResponse = AWS.DynamoDB.DeleteTableAsync(new DeleteTableRequest()
            {
                TableName = tableName,
            }).GetAwaiter().GetResult();

            Assert.IsNotNull(deleteTableResponse);
            Assert.IsTrue(deleteTableResponse.HttpStatusCode == System.Net.HttpStatusCode.OK);

            #endregion
        }

        [TestMethod]
        public void AWSClientWithConfigFileTest()
        {
            AWS.LoadAwsCredentialsProfile(_region, "C:\\aws_developer.csv", "default");
          
            #region SNS
            //Create SNS Topic
            string snsTopic = "awssimpleclientssns";

            var createSNSResponse = AWS.SNS.CreateTopicAsync(new CreateTopicRequest()
            {
                 Name = snsTopic
            }).GetAwaiter().GetResult();

            Assert.IsNotNull(createSNSResponse);
            Assert.IsTrue(createSNSResponse.HttpStatusCode == System.Net.HttpStatusCode.OK);

            string snsTopicArn = createSNSResponse.TopicArn;

            //Delete SNS Topic
            //The deletion may not succeed, you may manually delete it later.
            var deleteSNSResponse = AWS.SNS.DeleteTopicAsync(new DeleteTopicRequest()
            {
                TopicArn = snsTopicArn,
            });

            Assert.IsNotNull(deleteSNSResponse);
            Assert.IsTrue(createSNSResponse.HttpStatusCode == System.Net.HttpStatusCode.OK);

            #endregion
        }
    }
}
