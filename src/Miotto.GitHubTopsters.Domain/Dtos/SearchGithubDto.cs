namespace Miotto.GitHubTopsters.Domain.Dtos
{
    public class SearchGithubDto
    {
        public int Quantity { get; set; }
        public List<string> Languages { get; set; } = new List<string>();
    }
}
