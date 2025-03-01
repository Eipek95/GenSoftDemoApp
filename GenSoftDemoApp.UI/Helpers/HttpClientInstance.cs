namespace GenSoftDemoApp.UI.Helpers
{
    public static class HttpClientInstance
    {
        public static HttpClient CreateClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7279/api/");
            return client;
        }
    }
}
