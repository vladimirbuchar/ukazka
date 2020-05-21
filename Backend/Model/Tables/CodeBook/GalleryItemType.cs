using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.CodeBook
{
    public struct GalleryItemTypeValue
    {
        public const string MAIN_IMAGE = "MAIN_IMAGE";
    }
    [Table("Cb_GalleryItemType")]
    public class GalleryItemType : CodeBook
    {
    }
}
