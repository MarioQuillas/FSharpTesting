module MovieNews.Data.Movies

type MovieSearchResult (result : option<Movie>) =
    member x.HasMovie = result <> None
    member x.Movie =
        match result with
        | Some movie -> movie
        | None -> invalidOp "Movie not found"

let GetMovieInfo name = async {
    let! infoWork = 
        TheMovieDb.getMovieInfoByName name
        |> Async.StartChild

    let! reviewWork =
        NYTReview.tryDownloadReviewByName name
        |> Async.StartChild

    let! top100 = Netflix.getTop100()
    let! review = reviewWork
    let! info = infoWork

    let basics =
        top100
        |> Seq.tryFind (fun m -> m.Title = name)
    match basics, info with
    | Some(basics), Some(details, cast) ->
        return
            { 
                Movie = basics
                Details = details
                Cast = cast
                Review = review
             } |> Some |> MovieSearchResult
    | _ -> return None |> MovieSearchResult }

let GetLatestsMovies() = async {
    let! top100 = Netflix.getTop100()
    return top100 |> Seq.take 20 }