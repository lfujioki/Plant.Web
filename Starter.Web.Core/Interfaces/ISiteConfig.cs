namespace Starter.Web.Core
{
    public interface ISiteConfig
    {
        string AwsAccessKey { get; }
        string AWSBucketName { get; }
        string AwsSecretAccessKey { get; }
        string GoogleApiKey { get; }
        string HomeUrlAdmin { get; }
        string HomeUrlCaseWorker { get; }
        string HomeUrlClient { get; }
        string HomeUrlDataCollector { get; }
        string HomeUrlSuperAdmin { get; }
        string RemoteFileDomain { get; }
        string SendGridApiKey { get; }
        string SiteAdminEmailAddress { get; }

        string SiteInboxEmailAddress { get; }
        string SiteDomain { get; }
    }
}