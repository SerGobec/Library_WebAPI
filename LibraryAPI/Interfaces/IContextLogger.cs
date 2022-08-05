namespace LibraryAPI.Interfaces
{
    public interface IContextLogger
    {
        public Task WriteToLog(Microsoft.AspNetCore.Http.HttpContext context);
    }
}
