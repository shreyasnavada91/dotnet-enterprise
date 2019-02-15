namespace Enterprise.Core.Responses;
public class PaginatedResponse<T> : ApiResponse<List<T>> { public int PageNumber { get; set; } }
