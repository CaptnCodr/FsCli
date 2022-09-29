﻿namespace Fli

[<AutoOpen>]
module Domain =

    type ICommandContext<'a> =
        abstract member Context: 'a

    type ShellConfig = { Shell: Shells; Command: string }

    and Shells =
        | CMD
        | PS
        | PWSH
        | BASH

    type ProgramConfig = { Program: string; Arguments: string }

    type Config =
        { ShellConfig: ShellConfig
          ProgramConfig: ProgramConfig }

    type ShellContext =
        { config: ShellConfig }

        interface ICommandContext<ShellContext> with
            member this.Context = this

    type ProgramContext =
        { config: ProgramConfig }

        interface ICommandContext<ProgramContext> with
            member this.Context = this