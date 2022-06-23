using System.Net.Http.Headers;

internal class Program
{
  private static readonly HttpClient client = new HttpClient();
  static async Task Main(string[] args)
  {
    await ProcessRepositories();
  }

  private static async Task ProcessRepositories()
  {
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
    client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

    var stringTask = client.GetStringAsync("http://localhost:7000/ABI/api/ad/obter-usuario/marcelopel");

    var msg = await stringTask;
    Console.Write(msg);
  }
}