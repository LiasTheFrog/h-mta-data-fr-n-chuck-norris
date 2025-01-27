using System.Net.Http;
using System.Text.Json;



class Program{

static async Task Main(){
    JsonSerializerOptions options = new JsonSerializerOptions{WriteIndented = true};

using(HttpClient kalle = new HttpClient()){

 kalle.BaseAddress = new Uri ("https://api.chucknorris.io");

try{
    HttpResponseMessage response =  await kalle.GetAsync("jokes/random");
    response.EnsureSuccessStatusCode();

    string responseBody = await response.Content.ReadAsStringAsync();
    string JsonString = JsonSerializer.Serialize(responseBody,options);
    Console.WriteLine(JsonString);
}
catch(HttpRequestException e){
    Console.WriteLine(e.Message);
}
}
}


}

