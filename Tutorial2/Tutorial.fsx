#r @"../packages/FSharp.Data.2.3.3/lib/net40/FSharp.Data.dll"
#r @"System.Xml.Linq.dll"
open FSharp.Data
open System.Text.RegularExpressions

let regexThumb = Regex("<a[^>]*><img src=\"([^\"]*)\".*>(.*)")

let m = regexThumb.Match("""<a href="https://dvd.netflix.com/Movie/Nerve/80103475"><img src="//secure.netflix.com/us/boxshots/small/80103475.jpg"/></a><br>After becoming involved in an online version of "Truth or Dare," young Vee soon realizes that the game is anything but an innocent lark as her audience of anonymous "watchers" begins to manipulate her life in dangerous ways.
""")

m.Success
m.Groups.Count
m.Groups.[0].Value
m.Groups.[1].Value
m.Groups.[2].Value

// this two doesn't exist but we get an empty value when calling them and not an exception (Option or Maybe)
//m.Groups.[3].Value
//m.Groups.[4].Value

type Netflix = 
    XmlProvider<"http://dvd.netflix.com/Top100RSS">

let top = Netflix.GetSample()
top.Channel.Title

for it in top.Channel.Items do
    printfn "%s\n%s\n" it.Title.String.Value it.Description

