# AWS Simple Clients

This is a wrapper project for AWS clients which contains a creator(class) to instantiate aws service clients.

## Working with Credentials
Before invoke an aws client, developer must provide a valid credential to construct an Amazon Config object for each aws service client.
These are two ways to provide the credential:

#### 1. Provides the Access Key & Secret Key 
Developer provides both access key and secret key to construct AWS credential.

```c#
  private Amazon.RegionEndpoint _region = Amazon.RegionEndpoint.APSoutheast1; //sample region
  private string _accessKey = "<Your Access Key>";                         
  private string _secretKey = "<Your Secret Key>";       
        
  AWS.LoadAWSBasicCredentials(_region, _accessKey, _secretKey);
```

#### 2. Provide location path of the credential profile file.
Developer provides location file of the security credential file.

```c#
  //Download your security credential file to your machine
  //Example of aws_developer.csv: 
  //[default]
  //aws_access_key_id=<Your Access Key>
  //aws_secret_access_key=<Your Secret Key>
  
  AWS.LoadAwsCredentialsProfile(_region, "C:\\aws_developer.csv", "default");
```

## How to invoke AWS Clients ?
You can type ```AWS``` and followed by ```.``` to see all available aws service client objects. Choose an aws client object (e.g: S3) to access its functions.

Example :
1. S3 
```c#
  var resposne = AWS.S3.PutBucketAsync(...
```
2. SNS
```c#
  var response = AWS.SNS.CreateTopicAsync(...
```
3. DyamoDB
```c#
  var resposne =  AWS.DynamoDB.CreateTableAsyn(...
```

## Testing
Please refer the AWSSimpleClient test project for more sample code.

## License
This project is licensed under the MIT License.




Happy Coding :)

