namespace Atos.DevSkills.Domain.ViewModel
{
    public class ResponseViewModel<T>
    {
        public T Data { get; set; }        

        public ResponseViewModel(T data) 
        { 
            Data = data;
        }        
    }
}
