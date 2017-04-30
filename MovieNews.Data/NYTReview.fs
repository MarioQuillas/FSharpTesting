﻿module MovieNews.Data.NYTReview
open FSharp.Data

type NYT =
    JsonProvider<"http://api.nytimes.com/svc/movies/v2/reviews/search.json?api-key=9b917cfa4dcc4e639256a20c700670be&query=paddington">

let baseUrl = "http://api.nytimes.com/svc/movies/v2/reviews/search.json"
let apiKey = "9b917cfa4dcc4e639256a20c700670be"

let tryPickReviewByName name =
    let q = ["api-key", apiKey; "query", name]
    let response = Http.RequestString(baseUrl,q)
    let nyt = NYT.Parse(response)

    let reviewOpt = nyt.Results |> Seq.tryFind(fun r ->
        System.String.Equals(r.DisplayTitle, name, System.StringComparison.InvariantCultureIgnoreCase))
    
    reviewOpt |> Option.map(fun r ->
        {
            Published = r.PublicationDate
            Summary = r.SummaryShort
            Link = r.Link.Url
            LinkText = r.Link.SuggestedLinkText
        })


