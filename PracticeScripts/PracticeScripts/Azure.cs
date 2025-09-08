using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace PracticeScripts
{
    internal class Azure
    {
    }
    #region Service bus
        /*
         Azure Service Bus is a fully managed enterprise message broker that:

            Provides reliable cloud messaging as a service (MaaS)
            Supports pub/sub and point-to-point messaging patterns
            Offers message queues and topics/subscriptions
            Ensures message durability and at-least-once delivery
            Provides ordering, duplication detection, and dead-lettering

        Use when:
            Decoupling microservices
            Implementing event-driven architectures
            Handling high-volume messaging
            Needing reliable message delivery
            Integrating cloud and on-premises systems 

        Main components    
            Queues: Point-to-point messaging (1:1)
            Topics: Pub/sub messaging (1:many)
            Subscriptions: Consumers of topics (each gets copy of message)
            Namespaces: Container for messaging components
            Dead-letter queues: For problematic messages

        Messaging tiers
            Basic: Basic queues, limited features, low cost
            Standard: Topics/subscriptions, sessions, duplicate detection
            Premium: Dedicated resources, predictable performance, geo-disaster recovery

        // Install required package: Azure.Messaging.ServiceBus

        // Send messages
            await using var client = new ServiceBusClient(connectionString);
            ServiceBusSender sender = client.CreateSender("myqueue");

        // Create and send a message
            ServiceBusMessage message = new ServiceBusMessage("Hello World!");
            await sender.SendMessageAsync(message);

        // Receive messages
            ServiceBusReceiver receiver = client.CreateReceiver("myqueue");
            ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

        if (receivedMessage != null)
        {
            string body = receivedMessage.Body.ToString();
            Console.WriteLine($"Received: {body}");

            // Complete the message (remove from queue)
            await receiver.CompleteMessageAsync(receivedMessage);
        }

        */
        #endregion

        #region SNS and SQS
        /*
            Queues: Point-to-point messaging (similar to SQS)

            Topics/Subscriptions: Pub/sub messaging (similar to SNS)
        */
        #endregion

        #region Functions
        /*
          Azure Functions are serverless compute services that:
                Execute code in response to events/triggers
                Automatically scale based on demand
                Use pay-per-execution pricing model
                Support multiple programming languages (C#, JavaScript, Python, etc.)
                Enable event-driven architectures

            Use when:
                Building microservices and APIs
                Processing background tasks
                Real-time file/stream processing
                Scheduled tasks (cron jobs)
                Event-driven workflows

            Different hosting plans:
                Consumption Plan: True serverless, scale to zero, pay per execution
                Premium Plan: Pre-warmed instances, VNET integration, unlimited execution duration
                Dedicated (App Service) Plan: Runs on dedicated VMs, full control over scaling

            Common triggers:
                HTTP: Web APIs, webhooks
                Timer: Scheduled tasks (cron expressions)
                Blob Storage: File uploads/changes
                Queue Storage: Message processing
                Service Bus: Enterprise messaging
                Event Hubs: Stream processing
                Cosmos DB: Database changes
                Event Grid: Event-driven architecture

            Bindings: Bindings are declarative connections to data and services that
                Simplify integration with other Azure services
                Eliminate boilerplate code for common operations
                Support input (read data), output (write data), and trigger (invoke function) types
                Are configured via attributes in code or function.json

                Trigger bindings: Invoke function execution (HTTP, Timer, Queue, Blob, etc.)
                Input bindings: Provide data to the function (read operations)
                Output bindings: Send data from the function (write operations)


            Example of an HTTP-triggered Azure Function in C#:

        [FunctionName("HttpExample")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] 
        HttpRequest req,
        ILogger log)
    {
        log.LogInformation("C# HTTP trigger function processed a request.");

        string name = req.Query["name"];
        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        dynamic data = JsonConvert.DeserializeObject(requestBody);
        name = name ?? data?.name;

        return name != null
            ? (ActionResult)new OkObjectResult($"Hello, {name}")
            : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
    }

        //Timer Trigger -> TimerTrigger('0 * / 5 ****')] TimerInfo myTimer
        */
        #endregion

        #region AWS Lambda
        /*
         Runs code in response to events without provisioning servers
            Automatically scales from zero to thousands of parallel executions
            Uses pay-per-use pricing (duration and memory)
            Supports multiple languages (Python, Node.js, Java, C#, Go, Ruby)

        Key differences from Azure Functions:
            Cold starts: Both have cold starts, but different optimization approaches
            Triggers: Different service integrations (S3 vs Blob Storage, etc.)
            Pricing: Different calculation models (memory duration vs execution units)
            Ecosystem: Tight AWS vs Azure service integration

        execution concepts
            Handler function: Entry point for your code
            Event object: Data passed to the function from the trigger
            Context object: Runtime information about the function
            Execution role: IAM role defining permissions
            Layers: Shared code and dependencies
            Environment variables: Configuration values
        */
        #endregion

        #region Pipelines
        /*
         Azure Pipelines is a CI/CD service in Azure DevOps that:
            Automates build, test, and deployment processes
            Supports any language, platform, and cloud
            Provides YAML-based pipeline as code configuration
            Offers parallel jobs for running multiple processes simultaneously
            Integrates with GitHub, Azure Repos, and other repositories

         Key components
                Pipeline: Defines the CI/CD process
                Stages: Major divisions (Build, Test, Deploy)
                Jobs: Units of work within stages
                Steps: Individual tasks in jobs
                Tasks: Pre-built or custom actions
                Artifacts: Build outputs for deployment
                Triggers: Events that start pipeline runs

            CI (Continuous Integration): Automatically builds and tests code changes
            CD (Continuous Deployment): Automatically deploys tested changes to environments
            CR (Continuous Release): Manual approval gates before deployment

# azure-pipelines.yml
    trigger:
      branches:
        include:
        - main
        - releases/*

    pool:
      vmImage: 'ubuntu-latest'

    stages:
    - stage: Build
      jobs:
      - job: BuildJob
        steps:
        - task: UseDotNet@2
          inputs:
            packageType: 'sdk'
            version: '6.0.x'

        - script: dotnet build --configuration Release
          displayName: 'Build solution'

        - task: DotNetCoreCLI@2
          inputs:
            command: 'test'
            projects: '** /* Tests.csproj'
    
    - task: PublishBuildArtifacts@1
      inputs:
        PathtoPublish: '$(Build.ArtifactStagingDirectory)'
        ArtifactName: 'drop'
        publishLocation: 'Container'

- stage: Deploy
  dependsOn: Build
  condition: succeeded()
  jobs:
  - job: DeployJob
    steps:
    - download: current
      artifact: drop
    
    - task: AzureWebApp@1
      inputs:
        azureSubscription: 'my-azure-subscription'
        appType: 'webApp'
        appName: 'my-web-app'
        package: '$(Pipeline.Workspace)/drop/** /*.zip'


    */
    #endregion

}
