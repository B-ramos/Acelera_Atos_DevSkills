namespace Atos.DevSkills.Domain.ViewModel
{
    public class DefaultViewModel<T>
    {
        public T Data { get; set; }
        public int CodError { get; set; } = 0;

        public DefaultViewModel(T data) 
        { 
            Data = data;
        }

        public DefaultViewModel(int codError) 
        {
            CodError = codError;
        }
    }
}
