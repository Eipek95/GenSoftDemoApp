namespace GenSoftDemoApp.UI.Models
{
    public class ResponseModel<T>
    {
        public T data { get; set; }
        public int statusCode { get; set; }
        public Error error { get; set; }
    }

    public class Error
    {
        public string[] errors { get; set; }
        public bool isShow { get; set; }
    }

}


