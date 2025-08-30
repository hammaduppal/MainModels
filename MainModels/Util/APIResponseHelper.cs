using Microsoft.AspNetCore.Mvc;

namespace MainModels.Util
{
    public class APIResponseHelper
    {
        public static IActionResult ResultResponse(ControllerBase controller, int result, string? customSuccessMessage = null, string? customFailureMessage = null)
        {
            OperationStatus status = Enum.IsDefined(typeof(OperationStatus), result)
                ? (OperationStatus)result
                : OperationStatus.Failed; // fallback for unknown values

            string message = status == OperationStatus.Success
                ? (customSuccessMessage ?? status.GetMessage())
                : (customFailureMessage ?? status.GetMessage());

            return controller.Ok(new
            {
                statusCode = status.GetStatusCode(),
                Message = message
            });
        }



    }
    public static class OperationStatusExtensions
    {
        public static string GetMessage(this OperationStatus status)
        {
            return status switch
            {
                OperationStatus.Success => "Operation completed successfully.",
                OperationStatus.AlreadyExists => "Record already exists.",
                OperationStatus.NotFound => "No record found.",
                OperationStatus.Failed => "Operation failed.",
                OperationStatus.InvalidInput => "Invalid input data.",
                OperationStatus.Conflict => "There is a conflict.",
                OperationStatus.DuplicateProgress => "Progress already exists.",
                _ => "Unknown status"
            };
        }

        public static string GetStatusCode(this OperationStatus status)
        {
            return status switch
            {
                OperationStatus.Success => "200",
                OperationStatus.AlreadyExists => "201",
                OperationStatus.NotFound => "202",
                OperationStatus.Failed => "300",
                OperationStatus.InvalidInput => "301",
                OperationStatus.Conflict => "302",
                OperationStatus.DuplicateProgress => "303",
                _ => "999"
            };
        }
    }
    public enum OperationStatus
    {
        Success = 1,
        AlreadyExists = -1,
        NotFound = -2,
        Failed = 0,
        InvalidInput = -3,
        Conflict = -4,
        DuplicateProgress = -5
    }
}
