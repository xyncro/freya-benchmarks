module Freya.Benchmarks

open BenchmarkDotNet.Configs
open BenchmarkDotNet.Diagnostics.Windows
open BenchmarkDotNet.Exporters
open BenchmarkDotNet.Jobs

(* Instances *)

let benchmarkConfiguration =

    ManualConfig
        .Create(DefaultConfig.Instance)

        // Jobs

        // Legacy / Any

        .With(Job.Default
            .With(GarbageCollection (Server = true))
            .With(Jit.LegacyJit)
            .With(Platform.AnyCpu))

        // Ryu / Any

        .With(Job.Default
            .With(GarbageCollection (Server = true))
            .With(Jit.RyuJit)
            .With(Platform.AnyCpu))

        // Legacy / x86

        .With(Job.Default
            .With(GarbageCollection (Server = true))
            .With(Jit.LegacyJit)
            .With(Platform.X86))

        // Ryu / x86

        .With(Job.Default
            .With(GarbageCollection (Server = true))
            .With(Jit.RyuJit)
            .With(Platform.X86))

        // Legacy / x64

        .With(Job.Default
            .With(GarbageCollection (Server = true))
            .With(Jit.LegacyJit)
            .With(Platform.X64))

        // Ryu / x64

        .With(Job.Default
            .With(GarbageCollection (Server = true))
            .With(Jit.RyuJit)
            .With(Platform.X64))

        // Diagnostics

        // GC/Memory

        .With(MemoryDiagnoser ())

        // Inlining

        .With(InliningDiagnoser ())

        // Exporters

        .With(MarkdownExporter.GitHub)