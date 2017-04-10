// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

//let test x y =
//    x+y

//open System

//let readInput() = 
//    let s = Console.ReadLine()
//    match Int32.TryParse(s) with
//    | (true, parsed)  -> Some(parsed)
//    | _ -> None

//let tot = 
//    1+1+1

type Tree = 
    | Node of int*Tree list

//type QueryInfo =
//    {
//    Title : string
//    Check : Client -> bool
//    Positive : Decision
//    Negative : Decision}
//    and Decision =
//    | Result of string
//    | Query of QueryInfo



[<EntryPoint>]
let main argv = 
    printfn "%A" argv

    0 // return an integer exit code



