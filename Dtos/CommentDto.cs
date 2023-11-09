
using System ;
namespace IqraPearls.Dtos{
 
    public  record  commentDto {
        public string ProductComment { get; set; }
        public int  ProductId { get; set; }
        public int CustomerId{ get; set; }
        public int ParentCommentId {get; set;}
        
}

}