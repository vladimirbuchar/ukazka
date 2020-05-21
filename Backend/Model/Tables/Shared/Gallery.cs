using Model.Tables.CodeBook;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Shared
{
    [Table("Shared_Gallery")]
    public class Gallery : TableModel
    {
        [Column("FileName")]
        public virtual string FileName { get; set; }
        public virtual GalleryItemType GalleryItemType { get; set; }

    }
}
