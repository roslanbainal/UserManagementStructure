namespace UserManagement.Converters
{
    public class FileToBytes
    {
        public static async Task<byte[]> GetBytes(IFormFile formfile)
        {
            using (var memoryStream = new MemoryStream())
            {
                await formfile.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
