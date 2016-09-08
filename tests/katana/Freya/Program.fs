open Freya.Core
open Freya.Machines.Http
open Freya.Routers.Uri.Template

let name =
    freya {
        let! name = Freya.Optic.get (Route.atom_ "name")

        match name with
        | Some name -> return name
        | _ -> return "World" }

let hello =
    freya {
        let! name = name

        return Represent.text (sprintf "Hello %s!" name) }

let machine =
    freyaMachine {
        handleOk hello }

let router =
    freyaRouter {
        resource "/hello{/name}" machine }

type HelloWorld () =
    member __.Configuration () =
        OwinAppFunc.ofFreya (router)

open System
open Microsoft.Owin.Hosting

[<EntryPoint>]
let main _ =

    let _ = WebApp.Start<HelloWorld> ("http://*:7000")
    let _ = Console.ReadLine ()

    0