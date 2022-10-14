namespace ETicaretAPI.Application.Exeptions;

public class UserCreatetFailedEception : Exception
{
   public UserCreatetFailedEception() : base("Kullanıcı Oluşturulurken beklenmeyen bir Hata oluştu !")
   {
      
   }


   public UserCreatetFailedEception(string? message) : base(message)
   {
      
   }


   public UserCreatetFailedEception( string? message, Exception innerException) : base(message,innerException)
   {
      
   }
}