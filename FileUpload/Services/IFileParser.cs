using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;


namespace API.services
{
    public interface IFileParser
    {
        object Parse(IFormFile file);
    }
}
