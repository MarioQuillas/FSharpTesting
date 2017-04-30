module MovieNews.Data.Netflix

open FSharp.Data
open System.Text.RegularExpressions

let regexThumb = Regex("<a[^>]*><img src=\"([^\"]*)\".*>(.*)")

type Netflix = 
    XmlProvider<"http://dvd.netflix.com/Top100RSS">

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


