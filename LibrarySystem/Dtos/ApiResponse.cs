namespace LibrarySystem.Dtos
{
    public class ApiResponse
    {
       public bool Success { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
        public ApiResponse(bool success, string message, dynamic data = null)
        {
            Success = success;
            Message = message;
            Data = data;
        }
        
    }
}
