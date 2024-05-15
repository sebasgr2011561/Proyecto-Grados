﻿using Microsoft.AspNetCore.Http;

namespace Application.Interfaces
{
    public interface IFileStorageLocalApplication
    {
        Task<string> SaveFile(string container, IFormFile file);
        Task<string> EditFile(string container, IFormFile file, string route);
        Task RemoveFile(string route, string container);
    }
}
