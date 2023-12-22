namespace Sharpmind.Mindmaps

type 'a IMindmap =
    abstract member Value: 'a
    abstract member Children: 'a IMindmap seq

type 'a IImmutableMindmap =
    inherit IMindmap<'a>
    abstract member Children: 'a IImmutableMindmap list

type 'a IMutableMindmap =
    inherit IMindmap<'a>
    abstract member Value: 'a with get, set
    abstract member Children: 'a IMutableMindmap System.Collections.Generic.List

type 'a Mindmap =
    { Value: 'a
      Children: 'a Mindmap list }

    interface IImmutableMindmap<'a> with
        member this.Value = this.Value
        member this.Children: 'a IMindmap seq = this.Children |> List.map (fun x -> x)
