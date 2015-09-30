Imports BoolFuncExpression = System.Linq.Expressions.Expression(Of System.Func(Of Boolean))
Imports System.Runtime.CompilerServices

Public Class Expressions
    ''' <summary>
    ''' x = 0
    ''' </summary>
    Public Shared ReadOnly Property SimpleClosure As BoolFuncExpression
        Get
            Dim x = 1
            Return Function() x = 0
        End Get
    End Property

    ''' <summary>
    ''' x = "bar"
    ''' </summary>
    Public Shared ReadOnly Property StringEqual As BoolFuncExpression
        Get
            Dim x = "foo"
            Return Function() x = "bar"
        End Get
    End Property

    ''' <summary>
    ''' x &lt;&gt; "foo"
    ''' </summary>
    Public Shared ReadOnly Property StringNotEqual As BoolFuncExpression
        Get
            Dim x = "foo"
            Return Function() x <> "foo"
        End Get
    End Property

    ''' <summary>
    ''' ModuleFunction() = False
    ''' </summary>
    Public Shared ReadOnly Property CallModuleFunction As BoolFuncExpression
        Get
            Return Function() ModuleFunction() = False
        End Get
    End Property

    ''' <summary>
    ''' ModuleProperty = False
    ''' </summary>
    Public Shared ReadOnly Property GetModuleProperty As BoolFuncExpression
        Get
            Return Function() ModuleProperty = False
        End Get
    End Property
End Class
