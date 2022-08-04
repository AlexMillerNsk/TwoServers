module Server

open System.IO
open Suave
open Suave.Utils
open Filters
open Operators

let greetings q =
  defaultArg (Option.ofChoice (q ^^ "name")) "World" |> sprintf "Hello %s"
let app: WebPart =
     choose [
          GET >=> path "/" >=> Successful.OK "Hello GET"   
          GET >=> path "/test" >=> Successful.OK "Biden666"
          GET  >=> request (fun r -> Successful.OK (greetings r.query))
          RequestErrors.NOT_FOUND "Page not found." ]

let config = {
    defaultConfig with
        homeFolder = Some(Path.GetFullPath "./public")
}

startWebServer config app

