using System ;
namespace IqraPearls.Dtos{
 
    public record  ProductReviewDto {
      
     public int ProductId{get; set;}
     public int CustomerId{get; set;}
     public int ReviewValue{get; set;}

}

}