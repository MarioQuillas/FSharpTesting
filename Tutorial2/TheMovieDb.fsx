#r @"../packages/FSharp.Data.2.3.3/lib/net40/FSharp.Data.dll"
open FSharp.Data

let apiKey = "104ca45141181f9e2407e992d43abee3"

let searchUrl = 
    "http://api.themoviedb.org/3/search/movie"

let detailsUrl id =
    sprintf "http://api.themoviedb.org/3/movie/%d" id

let creditUrl id =
    sprintf "http://api.themoviedb.org/3/movie/%d/credits" id

type MovieSearch = JsonProvider<"MovieSearch.json">
type MovieCast = JsonProvider<"MovieCast.json">
type MovieDetails = JsonProvider<"MovieDetails.json">

let tryGetMovieId title =
    let jsonResponse =
        Http.RequestString(
            searchUrl,
            query = ["api_key", apiKey; "query", title],
            headers = [HttpRequestHeaders.Accept "application/json"])
    let searchRes = MovieSearch.Parse(jsonResponse)
    searchRes.Results
    |> Seq.tryFind(fun res ->
        res.Title = title)
    |> Option.map (fun res -> res.Id)




type Search = JsonProvider<"""{"page":1,"results":
[{"poster_path":"\/nBNZadXqJSdt05SHLqgT0HuC5Gm.jpg","adult":false,"overview":"Interstellar chronicles the adventures of a group of explorers who make use of a newly discovered wormhole to surpass the limitations on human space travel and conquer the vast distances involved in an interstellar voyage.","release_date":"2014-11-05","genre_ids":[12,18,878],"id":157336,"original_title":"Interstellar","original_language":"en","title":"Interstellar","backdrop_path":"\/xu9zaAevzQ5nnrsXN6JcahLnG4i.jpg","popularity":29.468765,"vote_count":8365,"video":false,"vote_average":8},{"poster_path":"\/cjvTebuqD8wmhchHE286ltVcbX6.jpg","adult":false,"overview":"For Millennia the Aliien force has watched and waited, a brooding menace that has now at last decided to take over the Earth. Communications systems worldwide are sent into chaos by a strange atmospheric interference and this has turned into a global phenomenon. A massive spaceship headed towards Earth and smaller spaceships began to cover entire cities around the world. Suddenly, the wonder turns into horror as the spaceships destroy the cities with energy weapons. When the world counterattacks, the alien ships are invincible to military weapons.  The survivors have to use their wits to kill the aliens, or die.","release_date":"2016-05-23","genre_ids":[878],"id":398188,"original_title":"Interstellar Wars","original_language":"en","title":"Interstellar Wars","backdrop_path":"\/yTnHa6lgIv8rNneSNBDkBe8MnZe.jpg","popularity":1.126309,"vote_count":5,"video":false,"vote_average":4.7},{"poster_path":"\/ngAjjio3au5PyuDPbqDPmd8vMzc.jpg","adult":false,"overview":"","release_date":"","genre_ids":[878],"id":439557,"original_title":"Interstellar Wars","original_language":"de","title":"Interstellar Wars","backdrop_path":null,"popularity":1.017611,"vote_count":0,"video":false,"vote_average":0},{"poster_path":"\/xZwUIPqBHyJ2QIfMPANOZ1mAld6.jpg","adult":false,"overview":"Behind the scenes of Christopher Nolan's sci-fi drama, which stars Matthew McConaughey and Anne Hathaway","release_date":"2014-11-05","genre_ids":[99],"id":301959,"original_title":"Interstellar: Nolan's Odyssey","original_language":"en","title":"Interstellar: Nolan's Odyssey","backdrop_path":"\/bT5jpIZE50MI0COE8pOeq0kMpQo.jpg","popularity":1.130174,"vote_count":88,"video":false,"vote_average":7.9},
{"poster_path":"\/buoq7zYO4J3ttkEAqEMWelPDC0G.jpg","adult":false,"overview":"An undeniably beautiful alien is sent to Earth to study the complex mating rituals of human beings, which leads to the young interstellar traveler experiencing the passion that surrounds the centuries-old ritual of the species.","release_date":"2014-03-08","genre_ids":[10770,35],"id":287954,"original_title":"Lolita from Interstellar Space","original_language":"en","title":"Lolita from Interstellar Space","backdrop_path":"\/mgb6tVEieDYLpQt666ACzGz5cyE.jpg","popularity":1.219537,"vote_count":1,"video":false,"vote_average":7},{"poster_path":"\/6KBD7YSBjCfgBgHwpsQo3G3GGdx.jpg","adult":false,"overview":"The science of Christopher Nolan's sci-fi, Interstellar.","release_date":"2014-11-25","genre_ids":[99],"id":336592,"original_title":"The Science of Interstellar","original_language":"en","title":"The Science of Interstellar","backdrop_path":null,"popularity":1.027265,"vote_count":3,"video":false,"vote_average":7.3},{"poster_path":"\/69yr3oxBpSgua26RJkFmsm7plTG.jpg","adult":false,"overview":"Jack is now back in the future. He had since lost Lena, and finds out that he's lost his other wife Alice to none other than Harris. While heading out for another assignment, something goes awry with the TCL chamber. Jack finds himself in a whole new dimension. He also runs across a different version of trancers. These guys seem to be in control of this planet. Jack manages to assist a rebel group known as the \"Tunnel Rats\" crush the rule of the evil Lord Calaban.","release_date":"1994-02-02","genre_ids":[878,28],"id":47662,"original_title":"Trancers 4: Jack of Swords","original_language":"en","title":"Trancers 4: Jack of Swords","backdrop_path":"\/5ism2HNUGuQi5a3ajYaN9ypMQMf.jpg","popularity":1.014085,"vote_count":8,"video":false,"vote_average":5.5},{"poster_path":"\/epMaTjPDMbgC8TbW1ZToh4RNv0i.jpg","adult":false,"overview":"Jack Deth is back for one more round with the trancers. Jack must attempt to find his way home from the other-dimensional world of Orpheus, where magic works and the trancers were the ruling class (before Trancers IV, that is). Unfortunately, Jack's quest to find the mystical Tiamond in the Castle of Unrelenting Terror may be thwarted by the return of Caliban, king of the trancers who was thought dead.","release_date":"1994-11-04","genre_ids":[28,53,878],"id":47663,"original_title":"Trancers 5: Sudden Deth","original_language":"en","title":"Trancers 5: Sudden Deth","backdrop_path":"\/an0xpUEX1P1BI80sCpkU1pSoREx.jpg","popularity":1.002813,"vote_count":5,"video":false,"vote_average":5.4},{"poster_path":"\/ie5luS87ess1c5VgFhbGECJTQVK.jpg","adult":false,"overview":"A criminal sentenced to life on a prison planet reveals his true purpose: to extract revenge on the killers who murdered his family.","release_date":"2008-01-01","genre_ids":[878],"id":261443,"original_title":"Angry Planet","original_language":"en","title":"Angry Planet","backdrop_path":"\/u4JBwlGZN8hGeLxwu7Q0WmibACp.jpg","popularity":1.000677,"vote_count":1,"video":false,"vote_average":4.5}],"total_results":9,"total_pages":1}""">

let id = Search.GetSample().Results.[0].Id

Http.RequestString(
    detailsUrl id,
    query = ["api_key", apiKey],
    headers = [HttpRequestHeaders.Accept "application/json"])

Http.RequestString(
    creditUrl id,
    query = ["api_key", apiKey],
    headers = [HttpRequestHeaders.Accept "application/json"])

