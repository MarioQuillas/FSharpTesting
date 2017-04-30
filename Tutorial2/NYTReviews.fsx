#r @"../packages/FSharp.Data.2.3.3/lib/net40/FSharp.Data.dll"
open FSharp.Data



type NYT =
    JsonProvider<"http://api.nytimes.com/svc/movies/v2/reviews/search.json?api-key=9b917cfa4dcc4e639256a20c700670be&query=paddington">

let baseUrl = "http://api.nytimes.com/svc/movies/v2/reviews/search.json"
let apiKey = "9b917cfa4dcc4e639256a20c700670be"

let query = "the social network"//"paddington"

let q = ["api-key", apiKey; "query", query]
let response = Http.RequestString(baseUrl,q)
let nyt = NYT.Parse(response)
for res in nyt.Results do
    printfn "%s" res.DisplayTitle

//NYT.GetSample()