#r @"../packages/FSharp.Data.2.3.3/lib/net40/FSharp.Data.dll"
#r @"System.Xml.Linq.dll"
open FSharp.Data
open System.Text.RegularExpressions

let regexThumb = Regex("<a[^>]*><img src=\"([^\"]*)\".*>(.*)")

// this two doesn't exist but we get an empty value when calling them
// and not an exception (Option or Maybe)
//m.Groups.[3].Value
//let mm = regexThumb.Match("")
//let ff = mm.Groups.[4].Value

type Netflix = 
    XmlProvider<"http://dvd.netflix.com/Top100RSS">

type MovieBasics = 
    {
        Title : string
        Summary : string
        Thumbnail : option<string>
    }
      
let getTop100() = 
    let top = Netflix.GetSample()
    [
        for it in top.Channel.Items ->
            let m = regexThumb.Match(it.Description)
            let descr, thumb = 
                if m.Success then
                    m.Groups.[2].Value,
                    Some(m.Groups.[1].Value)
                else
                    it.Description, None
            {
                Title = it.Title.String.Value
                Summary = descr
                Thumbnail = thumb
            }
    ]

getTop100()