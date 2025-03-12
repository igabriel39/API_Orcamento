namespace API_Orcamento.Service.Exceptions
{
    public class ObjectNotFound : Exception
    {
        public ObjectNotFound(string erro):base(erro) 
        { }
    }
}
