//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace _03Model.Models
{
    using System;
    using System.Collections.Generic;
    
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations; 
    /*就算已經using ComponentModel, 若要使用DataAnnotations功能還是要另外using*/


    public partial class tStudent
    {
        [DisplayName("學號")]
        [Required(ErrorMessage ="學號為必填欄位")] /*Required為必填，ErrorMessage為未填資料時傳出的訊息*/
        [RegularExpression("[12][0-5][6-9][0-9]{3}", ErrorMessage ="學號格式錯誤")]  /*[]內為1碼，輸入可填寫的數字，若為連續數字可寫1234或1~4，英文字母則有大小寫之分。[0~9]{3}為0~9打3碼，{3,}為三碼〈含〉以上，{,3}為最少三碼，{3,10}為最少3碼最多10碼*/
        public string fStuId { get; set; }
       
        [DisplayName("姓名")]
        [Required(ErrorMessage = "姓名為必填欄位")]
        public string fName { get; set; }
        
        [DisplayName("E-Mail")]
        [Required(ErrorMessage = "E-Mail為必填欄位")]
        [EmailAddress (ErrorMessage = "E-Mail格式錯誤")]
        public string fEmail { get; set; }

        [DisplayName("成績")]
        [Required(ErrorMessage = "成績為必填欄位")]
        [Range(0,100, ErrorMessage = "成績請填寫0~100的數字")]
        public Nullable<int> fScore { get; set; }
    }
}
