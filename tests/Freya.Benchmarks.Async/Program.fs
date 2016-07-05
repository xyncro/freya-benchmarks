// Freya

open Freya.Benchmarks
open Freya.Core
open Freya.Machines.Http
open Freya.Routers.Uri.Template
open Freya.Testing
open Freya.Types.Http
open Freya.Types.Language

let ok =
    freya {
        return {
            Data = "Hello World!"B
            Description =
                { Charset = Some Charset.Utf8
                  Encodings = None
                  MediaType = Some MediaType.Text
                  Languages = Some [ LanguageTag.parse "en-gb"
                                     LanguageTag.parse "en" ] } } }

let machine =
    freyaMachine {
        handleOk ok }

let router =
    freyaRouter {
        route GET "/" machine }

// BenchmarkDotNet

open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running

type FreyaAsync () =

    [<Benchmark>]
    member __.Default () =
        evaluate Freya.empty router

// Main

[<EntryPoint>]
let main _ =

    let _ = BenchmarkRunner.Run<FreyaAsync> (benchmarkConfiguration)

    0
