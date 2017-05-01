module MovieNews.Data.Utils
open FSharp.Data

type ThrottleMessage =
    {
        Url : string
        Query : seq<string*string>
        Reply : AsyncReplyChannel<string>
    }

let agent = MailboxProcessor<ThrottleMessage>.Start(fun inbox -> 
    async {
        while true do
            let! req = inbox.Receive()
            let sw = System.Diagnostics.Stopwatch.StartNew()
            let! res =
                Http.AsyncRequestString(req.Url, List.ofSeq req.Query)
            req.Reply.Reply(res)
            let sleep = delay - (int sw.ElapsedMilliseconds)
            if sleep > 0 then do! Async.Sleep(sleep)
    }
)

