using ProjectManagementSystem.Application.Models;

namespace ProjectManagementSystem.API.Helpers;

public static class FormFilesExtensions
{
    public static IEnumerable<FileDTO> ToDTO(this IEnumerable<IFormFile> files)
    {
        return files.Select(f => f.ToDTO());
    }

    public static FileDTO ToDTO(this IFormFile file)
    {
        byte[] bytes;

        using (var stream = new MemoryStream())
        {
            file.CopyTo(stream);

            bytes = stream.ToArray();
        }

        var dto = new FileDTO()
        {
            Name = file.Name + Path.GetExtension(file.FileName),
            File = bytes
        };

        return dto;
    }
}