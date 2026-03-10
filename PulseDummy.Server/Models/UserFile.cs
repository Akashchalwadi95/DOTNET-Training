using System;
using System.Collections.Generic;

namespace PulseDummy.Server.Models;

public partial class UserFile
{
    public int UserFilesId { get; set; }

    public int UserId { get; set; }

    public string FileName { get; set; } = null!;

    public string FileType { get; set; } = null!;

    public int FileSize { get; set; }

    public byte[] FileContent { get; set; } = null!;

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? EditedBy { get; set; }

    public DateTime? EditedOn { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual User? EditedByNavigation { get; set; }

    public virtual User User { get; set; } = null!;
}
