namespace BookManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage ="ID Không được để trống")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Tiêu đề  Không được để trống")]
        [StringLength(100,ErrorMessage ="Tiêu đề không được quá 100 ký tự")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Nội Dung  Không được để trống")]
        [StringLength(255)] 
        public string Description { get; set; }

        [Required(ErrorMessage = "Tác giả  Không được để trống")]
        [StringLength(30, ErrorMessage = "Tác giả không được quá 30 ký tự ")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Hình ảnh Không được để trống")]
        [StringLength(255)]
        public string Image { get; set; }

        [Required(ErrorMessage = "Giá tiền  Không được để trống")]
        [Range(1000, 1000000, ErrorMessage = "Giá sách từ 1000- 1000000")]
        public int Price { get; set; }
    }
}
