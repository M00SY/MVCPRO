namespace Demo_PL.Helpers
{
    public static class DocumentSettings
    {
        public static string UploadFile(IFormFile file, string folderName)
        {
            //1. file location path
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/Files", folderName);
            
            //2. get file name and make it unique
            var fileName = $"{Guid.NewGuid()}-{Path.GetFileName(file.FileName)}";

            //3. get file path

            var filePath = Path.Combine(folderPath,fileName);

            // use file stream to make a copy of the file

            using var filestream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(filestream);

            return fileName;
        }
        public static int DeleteFile(string ImageUrl, string folderName)
        {
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", folderName);
            var filePath = Path.Combine(folderPath, ImageUrl);
            if(File.Exists(filePath))
            {
                File.Delete(filePath);
                return 0;
            }
            return -1;


        }
    }
}
