using System;
using System.Collections.Generic;

namespace PulseDummy.Server.Models;

public partial class FileUpload
{
    public int FileId { get; set; }

    public int? UserId { get; set; }

    public string? FileName { get; set; }

    public string? FilePath { get; set; }

    public string? FileType { get; set; }

    public DateTime? UploadDate { get; set; }

    public virtual UserDatum? User { get; set; }
}
