module Server

open System.IO
open Suave
open Filters
open Operators

let app: WebPart =
     choose [
          GET >=> path "/" >=> Files.file "./public/index.html"    
          GET >=> path "/test" >=> Successful.OK "Biden666"
          RequestErrors.NOT_FOUND "Page not found." ]

let config = {
    defaultConfig with
        bindings = [HttpBinding.createSimple Protocol.HTTP "192.168.68.100" 8080]
        homeFolder = Some(Path.GetFullPath "./public")
}

startWebServer config app