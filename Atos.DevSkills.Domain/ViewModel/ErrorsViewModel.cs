namespace Atos.DevSkills.Domain.ViewModel
{
    public class ErrorsViewModel
    {
        public IEnumerable<string> Errors { get; private set; }

        public ErrorsViewModel(IEnumerable<string> errors)
        {
            Errors = errors;
        }

        public ErrorsViewModel(string message)
        {
            var error = new List<string> { message };
            Errors = error;
        }
    }
}