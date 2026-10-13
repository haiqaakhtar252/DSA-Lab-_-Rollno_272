namespace DSALabsWeek01Api.Models
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }

        public static ApiResponse<T> Ok(T data, string message = "Success") =>
            new() { Success = true, Message = message, Data = data };

        public static ApiResponse<T> Fail(string message) =>
            new() { Success = false, Message = message, Data = default };
    }

    public class NumberRequest { public long N { get; set; } }
    public class TwoNumbersRequest { public long A { get; set; } public long B { get; set; } }
    public class DigitsRequest { public int Digits { get; set; } }
    public class AnalysisRequest { public long A { get; set; } public long B { get; set; } }

    public class StudentInfoRequest
    {
        public string Name { get; set; } = "";
        public string RegistrationNumber { get; set; } = "";
    }
}
