using FluentValidation.Results;

namespace Miotto.GitHubTopsters.Util
{
    public class Result<T>
    {
        public T Data { get; set; }
        public bool Error { get => Errors.Any(); }
        public List<ValidationFailure> Errors { get; set; } = new List<ValidationFailure>();
        
        public Result(T data)
        {
            Data = data;
        }

        public Result()
        {

        }
    }
}